using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Invoicing.API.Handlers.GetInvoices
{
    public class GetInvoicesQuery
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
    }
}
