using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services.Abstract;
using System;
using System.Linq;

namespace AutoStoreAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly ICustomersService customersService;
        private readonly IOptions<AuthOptions> authOptions;
        public AuthController(IAccountService accountService, ICustomersService customersService, IOptions<AuthOptions> authOptions)
        {
            this.customersService = customersService;
            this.accountService = accountService;
            this.authOptions = authOptions;

        }
        [HttpPost]
        public IActionResult Login([FromBody] Account account)
        {
            var acc = accountService.Get(account.Email, account.Password);
            if (acc != null)
            {
                authOptions.Value.Secret = Environment.GetEnvironmentVariable("Secret");
                var token = accountService.GenerateJWT(acc, authOptions);
                return Ok(new
                {
                    access_token = token
                });
            }
            else
            {
                var user = accountService.GetAll().SingleOrDefault(x => x.Email == account.Email);
                return user == null ?
                      Unauthorized(new { message = "Пользователь не зарегистрирован" }) :
                      Unauthorized(new { message = "Неверно введен пароль" });
            }
        }
        [HttpPost]
        public IActionResult Register([FromBody] Customer customer)
        {
            customersService.Add(customer);
            return Ok(new { message = "Спасибо за регистрацию" });
        }

    }
}
