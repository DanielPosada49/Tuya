using Microsoft.EntityFrameworkCore;
using Productos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Productos.DBContext
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Nombre = "Arroz",
                    Valor = 2500,
                },
                new Product
                {
                    Id = 2,
                    Nombre = "Salsa de Tomate",
                    Valor = 3000,
                },
                new Product
                {
                    Id = 3,
                    Nombre = "Huevo",
                    Valor = 450,
                }
            );
        }
    }
}
