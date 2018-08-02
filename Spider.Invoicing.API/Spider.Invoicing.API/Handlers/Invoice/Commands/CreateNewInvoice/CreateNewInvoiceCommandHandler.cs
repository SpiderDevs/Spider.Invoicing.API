using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spider.Invoicing.API.Database;
using Spider.Invoicing.API.Database.Models;
using Spider.Invoicing.API.DTO;
using Spider.Invoicing.API.Handlers.Interfaces;

namespace Spider.Invoicing.API.Handlers.Invoice.Commands.CreateNewInvoice
{
    public class CreateNewInvoiceCommandHandler : ICommandHandler<CreateNewInvoiceCommand>
    {
        private readonly InvoicingContext dbContext;

        public CreateNewInvoiceCommandHandler(InvoicingContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IResponse> Handle(CreateNewInvoiceCommand command)
        {
            var entity = new InvoiceTemporary()
            {
                InvoiceTemporaryId = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
            };

            dbContext.TemporaryInvoices.Add(entity);
            await dbContext.SaveChangesAsync();

            return new CreateNewInvoiceCommandResponse()
            {
                IsSuccess = true,
                Result = new Invoice()
                {
                    Id = entity.InvoiceTemporaryId,
                }
            };
        }
    }
}
