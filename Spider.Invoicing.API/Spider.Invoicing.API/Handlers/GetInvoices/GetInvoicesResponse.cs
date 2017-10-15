using Spider.Invoicing.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Invoicing.API.Handlers.GetInvoices
{
    public class GetInvoicesResponse : ResponseBase
    {
        internal List<Invoice> Invoices
        {
            get
            {
                return (List<Invoice>)Result;
            }
            set
            {
                Result = value;
            }
        }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
    }
}
