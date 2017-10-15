using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Invoicing.API.Database.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public Decimal GrossAmmount { get; set; }
        public Decimal NetAmount { get; set; }
        public Decimal VatAmount { get; set; }
    }
}
