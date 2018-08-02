using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spider.Invoicing.API.DTO;

namespace Spider.Invoicing.API.Handlers.Invoice.Commands.CreateNewInvoice
{
    public class CreateNewInvoiceCommandResponse : ResponseBase<Invoice>
    {
    }

    public class Invoice
    {
        public Guid Id { get; set; }
    }
}
