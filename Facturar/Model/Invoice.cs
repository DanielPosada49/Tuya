using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturar.Model
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string Document { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public int TotalValue { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
