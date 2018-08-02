using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spider.Invoicing.API.DTO;

namespace Spider.Invoicing.API.Handlers.Invoice.Queries.GetInvoices
{
    public class GetInvoicesQuery : IQuery
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
    }
}
