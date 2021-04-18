using Facturar.Model;
using Facturas.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturas.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly InvoiceContext _dbContext;

        public InvoiceRepository(InvoiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteInvoice(int InvoiceId)
        {
            var invoice = _dbContext.Invoices.Find(InvoiceId);
            _dbContext.Invoices.Remove(invoice);
            Save();
        }

        public IEnumerable<Invoice> GetInvoices()
        {
            return _dbContext.Invoices.ToList();
        }

        public Invoice GetInvoiceById(int InvoiceId)
        {
            return _dbContext.Invoices.Find(InvoiceId);
        }

        public void InsertInvoice(Invoice invoice)
        {
            var product = _dbContext.Products.Find(invoice.ProductId);

            if(product != null)
            {
                invoice.TotalValue = invoice.Amount * product.Valor;
                invoice.PurchaseDate = DateTime.Now;
                _dbContext.Add(invoice);
                Save();
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateInvoice(Invoice invoice)
        {
            _dbContext.Entry(invoice).State = EntityState.Modified;
            Save();
        }
    }
}
