using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Spider.Invoicing.API.Database;
using Spider.Invoicing.API.Database.Models;
using Spider.Invoicing.API.DTO;
using Spider.Invoicing.API.Handlers.Interfaces;

namespace Spider.Invoicing.API.Handlers.Invoice.Commands.CreateNewInvoice
{
    public class CreateNewInvoiceCommandHandler : ICommandHandler<CreateNewInvoiceCommand>
    {
        private readonly InvoicingContext dbContext;
        private readonly CreateNewInvoiceCommandValidator validator;

        public CreateNewInvoiceCommandHandler(InvoicingContext dbContext)
        {
            this.dbContext = dbContext;
            this.validator = new CreateNewInvoiceCommandValidator();
        }

        public async Task<IResponse> Handle(CreateNewInvoiceCommand command)
        {
            var validationResult = validator.Validate(command);
            if (!validationResult.IsValid)
            {
                return Error(validationResult);
            }

            var entity = new InvoiceTemporary()
            {
                InvoiceTemporaryId = command.Id.Value,
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

        private static IResponse Error(ValidationResult validationResult)
        {
            return new CreateNewInvoiceCommandResponse()
            {
                IsSuccess = false,
                Error = new Error()
                {
                    ErrorCode = ErrorCodeEnum.INVALID_REQUEST,
                    Message = "Invalid request",
                    Errors = validationResult.Errors.Select(x => new Error()
                    {
                        Message = x.ErrorMessage,
                    }).ToList(),
                }
            };
        }
    }

    public class CreateNewInvoiceCommandValidator : AbstractValidator<CreateNewInvoiceCommand>
    {
        public CreateNewInvoiceCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().NotEqual(Guid.Empty).WithMessage("New invoice id is required");
        }
    }

}
