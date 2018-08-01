using System;
using System.Collections.Generic;
using System.Linq;

namespace Spider.Invoicing.API.DTO
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public Decimal GrossAmmount { get; set; }
        public Decimal NetAmount { get; set; }
        public Decimal VatAmount { get; set; }
    }
}
