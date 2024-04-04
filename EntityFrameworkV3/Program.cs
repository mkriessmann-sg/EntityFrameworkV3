
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Design;
namespace EntityFrameworkV3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var dbPath = "mydatabase.db";

            using (var context = new MyDBContext())
            {
                // Add a new product
                var product = new Product()
                {
                    Id = 1,
                    Name = "Product A",
                    Description = "This is an awesome Product",
                    Price = 100,
                    stock = 10
                };

                context.Products.Add(product);
                context.SaveChanges();

                // Update a product
                var productToUpdate = context.Products.FirstOrDefault(p => p.Name == "Product A");
                if (productToUpdate != null)
                {
                    productToUpdate.Description = "Updated description";
                    context.SaveChanges();
                }

                // Delete a product
                var productToDelete = context.Products.FirstOrDefault(p => p.Name == "Product A");
                if (productToDelete != null)
                {
                    context.Products.Remove(productToDelete);
                    context.SaveChanges();
                }

            }

        }


        
    }
}
