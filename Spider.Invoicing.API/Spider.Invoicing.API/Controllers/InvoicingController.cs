using Microsoft.AspNetCore.Mvc;
using Spider.Invoicing.API.Controllers.Common;
using Spider.Invoicing.API.Handlers.GetInvoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Invoicing.API.Controllers
{
    [Route("api/[controller]")]
    public class InvoicingController : ApiController
    {
        private readonly GetInvoicesQueryHandler handler;

        public InvoicingController(GetInvoicesQueryHandler handler)
        {
            this.handler = handler;
        }

        /// <summary>
        /// Returm invoices
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IActionResult Get(GetInvoicesQuery query)
        {
            return Response(handler.Handle(query));
        }
    }
}
