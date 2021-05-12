using DataLayer.Repositories.Abstract;
using Domain;
using Mappers;
using Microsoft.AspNetCore.Http;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.IO;

namespace Services
{
    public class ProductService : IProductSrvice
    {
        private readonly IUnitOfWork unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void Add(Product domain)
        {
            unitOfWork.Product.Add(domain.ToEntity());
            unitOfWork.Save();
        }

        public void ConvertBase64ToImg(string imgInBase64, string imgPath)
        {
            var imgBytes = Convert.FromBase64String(imgInBase64);
            File.WriteAllBytes(imgPath, imgBytes);
        }

        public string ConverImgToBase64(Product product)
        {
            var ImgBytes = File.ReadAllBytes(product.Img);
            return Convert.ToBase64String(ImgBytes);
        }

        public IEnumerable<Product> GetAll()
        {

            return unitOfWork.Product.GetAll().ToDomain();
        }

        public Product GetById(Guid id)
        {
            return unitOfWork.Product.GetBy(product => product.Id == id).ToDomain();
        }

        public void Remove(Product domain)
        {
            var result = unitOfWork.Product.GetBy(product => product.Id == domain.Id);
            if (result != null)
            {
                unitOfWork.Product.Remove(result);
                unitOfWork.Save();
            }
        }

        public void Update(Product domain)
        {
            unitOfWork.Product.Update(domain.ToEntity());
            unitOfWork.Save();
        }

        public void Add(IFormFile file, Product product)
        {
            string path = $"{Environment.CurrentDirectory}\\Images\\noImage.png";
            Add(product);
            var _product = unitOfWork.Product.GetBy(_product => _product.Name == product.Name
                           && _product.Category == product.Category
                           && _product.Price == product.Price);
            if (_product != null )
            {
                if(file != null)
                {
                    path = $"{Environment.CurrentDirectory}\\Images\\{GetCateoryPath(product.Category)}\\{_product.Id}.png";
                    using Stream stream = new FileStream(path, FileMode.Create);
                    file.CopyTo(stream);
                }
                _product.ImgPath = path;
                unitOfWork.Save();
            }

        }
        private string GetCateoryPath(string categoryName)
        {
            string result = string.Empty;
            switch (categoryName.ToLower())
            {
                case "молочная продукция":
                    {
                        result = "milkProducts";
                        break;
                    }
                case "хлебная продукция":
                    {
                        result = "breadProducts";
                        break;
                    }
                case "фрукты":
                    {
                        result = "fruits";
                        break;
                    }
                case "овощи":
                    {
                        result = "vegetables";
                        break;
                    }
                case "макаронные изделия":
                    {
                        result = "pastaProducts";
                        break;
                    }
                case "бытовая химия":
                    {
                        result = "householdChemicals";
                        break;
                    }
            }
            return result;
        }
    }
}
