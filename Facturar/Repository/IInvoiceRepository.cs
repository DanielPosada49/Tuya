using Facturar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturas.Repository
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> GetInvoices();
        Invoice GetInvoiceById(int InvoiceId);
        void InsertInvoice(Invoice invoice);
        void DeleteInvoice(int InvoiceId);
        void UpdateInvoice(Invoice invoice);
        void Save();
    }
}
