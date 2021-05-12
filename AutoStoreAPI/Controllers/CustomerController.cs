using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace AutoStoreAPI.Controllers
{

    [Route("[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomersService customerService;
        public CustomerController(ICustomersService customerService)
        {
            this.customerService = customerService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(customerService.GetAll());
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Update([FromBody] Customer customer)
        {
            customerService.Update(customer);
            return Ok(new { message = "Пользователь обновлен" });
        }
    }
}
