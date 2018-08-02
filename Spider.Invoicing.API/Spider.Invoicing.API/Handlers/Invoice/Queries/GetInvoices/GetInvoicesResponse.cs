using Spider.Invoicing.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Invoicing.API.Handlers.Invoice.Queries.GetInvoices
{
    public class GetInvoicesResponse : ResponseBase<List<Invoice>> 
    {
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
    }

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
