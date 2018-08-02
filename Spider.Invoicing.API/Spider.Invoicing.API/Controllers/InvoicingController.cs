using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spider.Invoicing.API.Controllers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spider.Invoicing.API.Handlers.Invoice.Commands.CreateNewInvoice;
using Spider.Invoicing.API.Handlers.Invoice.Queries.GetInvoices;

namespace Spider.Invoicing.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class InvoicingController : ApiController
    {
        private readonly GetInvoicesQueryHandler getInvoicesQueryHandler;
        private readonly CreateNewInvoiceCommandHandler createNewInvoiceCommandHandlerhandler;

        public InvoicingController(GetInvoicesQueryHandler getInvoicesQueryHandler, CreateNewInvoiceCommandHandler createNewInvoiceCommandHandlerhandler)
        {
            this.getInvoicesQueryHandler = getInvoicesQueryHandler;
            this.createNewInvoiceCommandHandlerhandler = createNewInvoiceCommandHandlerhandler;
        }

        /// <summary>
        /// Returm invoices
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(GetInvoicesQuery query)
        {
            return Response(await getInvoicesQueryHandler.Handle(query));
        }

        /// <summary>
        /// Returm invoices
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("/new")]
        public async Task<IActionResult> Get(CreateNewInvoiceCommand command)
        {
            return Response(await createNewInvoiceCommandHandlerhandler.Handle(command));
        }
    }
}
