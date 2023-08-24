using AspNet6Course.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNet6Course.Data
{
    public class SeedData : DbContext
    {
        public static void SeedDatabase(AppDbContext context)
        {
            context.Database.Migrate();

            if (context.Products.Count() == 0 && context.Categories.Count() == 0)
            {
                Category clothes = new Category { Name = "clothes" };
                Category fruits = new Category { Name = "fruits" };
                Category electronics = new Category { Name = "electronics" };
                Category books = new Category { Name = "books" };
                Category accessories = new Category { Name = "accessories" };

                context.Products.AddRange(
                    new Product
                    {
                        Name = "apple",
                        price = 150M,
                        Category = fruits
                    },
                    new Product
                    {
                        Name = "banana",
                        price = 50M,
                        Category = fruits
                    },
                    new Product
                    {
                        Name = "t-shirt",
                        price = 500M,
                        Category = clothes
                    },
                    new Product
                    {
                        Name = "jeans",
                        price = 1200M,
                        Category = clothes
                    },
                    new Product
                    {
                        Name = "headphones",
                        price = 2500M,
                        Category = electronics
                    },
                    new Product
                    {
                        Name = "television",
                        price = 15000M,
                        Category = electronics
                    },
                    new Product
                    {
                        Name = "novel",
                        price = 300M,
                        Category = books
                    },
                    new Product
                    {
                        Name = "history book",
                        price = 450M,
                        Category = books
                    },
                    new Product
                    {
                        Name = "wrist watch",
                        price = 3200M,
                        Category = accessories
                    },
                    new Product
                    {
                        Name = "sunglasses",
                        price = 2100M,
                        Category = accessories
                    },
                    new Product
                    {
                        Name = "belt",
                        price = 700M,
                        Category = accessories
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
