using DataLayer;
using DataLayer.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AutoStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUnitOfWork UnitOfWork;
        public ValuesController(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }
        public IActionResult Index()
        {
            var result = UnitOfWork.Customer.GetBy(customer => customer.Name == "Ya");
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Item not found");
        }
    }
}
