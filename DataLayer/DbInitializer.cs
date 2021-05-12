using EntitiesDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class DbInitializer
    {
        public static string HostContentPath {get;set;}
        public static void Initialize(Context context)
        {
            context.Database.EnsureCreated();
            HostContentPath = $"{Environment.CurrentDirectory}\\Images";
            if (!context.Customers.Any())
            {
                var customers = new CustomerEntity[]
            {
                new CustomerEntity {
                    Name = "Иван Иванов",
                    Address = "Проспект Мира д.24",
                    Code = "0000-2021",
                    Account = new AccountEntity
                    {
                        Email = "admin@gmail.com",
                        Password = "12345",
                        Role = Role.Admin
                    }
                },
                new CustomerEntity {
                    Name = "Вячеслав Петров",
                    Address = "ул. Академика Янгеля д.5",
                    Code = "0001-2021",
                    Account = new AccountEntity
                    {
                        Email = "petrov@gmail.com",
                        Password = "12345",
                        Role = Role.User
                    },
                    Discount = 10
                },
                new CustomerEntity
                {
                    Name = "Александр Ветров",
                    Address = "ул. Планерная д.31",
                    Code = "0002-2021",
                    Account = new AccountEntity
                    {
                        Email = "vetrod@gmail.com",
                        Password = "12345",
                        Role = Role.User
                    },
                    Discount = 10
                }
            };
                context.Customers.AddRange(customers);
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                var products = new ProductEntity[]
                {
                    new ProductEntity {Name = "Молоко", Category ="молочная продукция", Price = 60, ImgPath=$"{HostContentPath}\\milkProducts\\milk.jpg"},
                    new ProductEntity {Name = "Творог", Category ="молочная продукция", Price = 90, ImgPath=$"{HostContentPath}\\milkProducts\\cottageCheese.jpg"},
                    new ProductEntity {Name = "Сметана", Category ="молочная продукция", Price = 78, ImgPath=$"{HostContentPath}\\milkProducts\\sourCream.jpg"},
                    new ProductEntity {Name = "Йогурт", Category ="молочная продукция", Price = 97, ImgPath=$"{HostContentPath}\\milkProducts\\yogurt.jpg"},
                    new ProductEntity {Name = "Масло", Category ="молочная продукция", Price = 110, ImgPath=$"{HostContentPath}\\milkProducts\\butter.jpg"},
                    new ProductEntity {Name = "Чизкэйк", Category ="молочная продукция", Price = 250, ImgPath=$"{HostContentPath}\\milkProducts\\cheeseCacke.jpg"},

                    new ProductEntity {Name = "Хлеб", Category ="хлебная продукция", Price = 50, ImgPath=$"{HostContentPath}\\breadProducts\\bread.jpg"},
                    new ProductEntity {Name = "Булочка с маком", Category ="хлебная продукция", Price = 63, ImgPath=$"{HostContentPath}\\breadProducts\\bun.jpg"},
                    new ProductEntity {Name = "Чиабата", Category ="хлебная продукция", Price = 102, ImgPath=$"{HostContentPath}\\breadProducts\\ciabatta.jpg"},
                    new ProductEntity {Name = "Батон", Category ="хлебная продукция", Price = 57, ImgPath=$"{HostContentPath}\\breadProducts\\loaf.jpg"},
                    new ProductEntity {Name = "Батон нарезной", Category ="хлебная продукция", Price = 60, ImgPath=$"{HostContentPath}\\breadProducts\\slicedLoaf.jpg"},
                    new ProductEntity {Name = "Кулич", Category ="хлебная продукция", Price = 220, ImgPath=$"{HostContentPath}\\breadProducts\\kulich.jpg"},

                    new ProductEntity {Name = "Банан", Category ="фрукты", Price = 61, ImgPath=$"{HostContentPath}\\fruits\\banana.jpg"},
                    new ProductEntity {Name = "Ананас", Category ="фрукты", Price = 150, ImgPath=$"{HostContentPath}\\fruits\\pineapple.jpg"},
                    new ProductEntity {Name = "Киви", Category ="фрукты", Price = 130, ImgPath=$"{HostContentPath}\\fruits\\qiwi.jpg"},
                    new ProductEntity {Name = "Яблоко", Category ="фрукты", Price = 78, ImgPath=$"{HostContentPath}\\fruits\\apple.jpg"},
                    new ProductEntity {Name = "Груша", Category ="фрукты", Price = 115, ImgPath=$"{HostContentPath}\\fruits\\pear.jpg"},
                    new ProductEntity {Name = "Виноград", Category ="фрукты", Price = 190, ImgPath=$"{HostContentPath}\\fruits\\grapes.jpg"},

                    new ProductEntity {Name = "Картофель", Category ="овощи", Price = 20, ImgPath=$"{HostContentPath}\\vegetables\\potato.jpg"},
                    new ProductEntity {Name = "Лук", Category ="овощи", Price = 15, ImgPath=$"{HostContentPath}\\vegetables\\onion.jpg"},
                    new ProductEntity {Name = "Морковь", Category ="овощи", Price = 18, ImgPath=$"{HostContentPath}\\vegetables\\carrot.jpg"},
                    new ProductEntity {Name = "Огурец", Category ="овощи", Price = 41, ImgPath=$"{HostContentPath}\\vegetables\\cucumber.jpg"},
                    new ProductEntity {Name = "Перец болгарский", Category ="овощи", Price = 68, ImgPath=$"{HostContentPath}\\vegetables\\bolgarPepper.jpg"},
                    new ProductEntity {Name = "Капута", Category ="овощи", Price = 22, ImgPath=$"{HostContentPath}\\vegetables\\cabbage.jpg"},

                    new ProductEntity {Name = "Спагети", Category ="макаронные изделия", Price = 30, ImgPath=$"{HostContentPath}\\pastaProducts\\spagetti.jpg"},
                    new ProductEntity {Name = "Рожки", Category ="макаронные изделия", Price = 31, ImgPath=$"{HostContentPath}\\pastaProducts\\macaroni-2.jpg"},
                    new ProductEntity {Name = "Вермишель", Category ="макаронные изделия", Price = 45, ImgPath=$"{HostContentPath}\\pastaProducts\\vermicelli.jpg"},
                    new ProductEntity {Name = "Лапша домашняя", Category ="макаронные изделия", Price = 60, ImgPath=$"{HostContentPath}\\pastaProducts\\homeNoodles.jpg"},
                    new ProductEntity {Name = "Ролтон", Category ="макаронные изделия", Price = 11, ImgPath=$"{HostContentPath}\\pastaProducts\\macaroni-3.jpg"},
                    new ProductEntity {Name = "Перья", Category ="макаронные изделия", Price = 34, ImgPath=$"{HostContentPath}\\pastaProducts\\macaroni-1.jpg"},

                    new ProductEntity {Name = "Мыло", Category ="бытовая химия", Price = 37, ImgPath=$"{HostContentPath}\\householdChemicals\\soap.jpg"},
                    new ProductEntity {Name = "Гель для посуды", Category ="бытовая химия", Price = 98, ImgPath=$"{HostContentPath}\\householdChemicals\\dishesGel.jpg"},
                    new ProductEntity {Name = "Порошок стиральный", Category ="бытовая химия", Price = 115, ImgPath=$"{HostContentPath}\\householdChemicals\\miss.jpg"},
                    new ProductEntity {Name = "Порошок чистящий", Category ="бытовая химия", Price = 42, ImgPath=$"{HostContentPath}\\householdChemicals\\miss-2.jpg"},
                    new ProductEntity {Name = "Шампунь", Category ="бытовая химия", Price = 113, ImgPath=$"{HostContentPath}\\householdChemicals\\shampoo.jpg"},
                    new ProductEntity {Name = "кондиционер для белья", Category ="бытовая химия", Price = 118, ImgPath=$"{HostContentPath}\\householdChemicals\\linenconditioner.jpg"},

                };
                context.Products.AddRange(products);
                context.SaveChanges();
            }

        }
    }

}
