using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistica.Model
{
    public class Logistic
    {
        public int Id { get; set; }
        public Guid Guide { get; set; }
        public int InvoiceId { get; set; }
        public DateTime DateSend { get; set; }
    }
}
