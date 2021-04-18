using Facturar.Model;
using Facturas.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturas.DBContext
{
    public class InvoiceContext : DbContext
    {
         public InvoiceContext(DbContextOptions<InvoiceContext> options) : base(options)
        {

        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
