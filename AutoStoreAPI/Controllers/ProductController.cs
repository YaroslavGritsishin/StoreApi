using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.IO;

namespace AutoStoreAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductSrvice productService;
        public ProductController(IProductSrvice productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(productService.GetAll());
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddProduct([FromForm] IFormFile file, IFormCollection data)
        {
            Product product = new Product
            {
                Category = data["category"],
                Name = data["name"],
                Price = double.Parse(data["price"])
            };
            productService.Add(file, product);
            return Ok(new { message = "Продукт добавлен"});
        }
        public IActionResult DeleteProduct([FromBody]  Product product )
        {
            productService.Remove(product);
            return Ok(new { message = "Продукт успешно удален" });
        }
    }
}
