using Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstract
{
    public interface IProductSrvice : IService<Product>
    {
        string ConverImgToBase64(Product product);
        void ConvertBase64ToImg(string imgInBase64, string imgPath);
        void Add(IFormFile file, Product product);
        
    }
}
