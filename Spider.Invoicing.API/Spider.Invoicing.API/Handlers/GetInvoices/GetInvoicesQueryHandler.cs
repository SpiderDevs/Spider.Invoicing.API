using Spider.Invoicing.API.Database;
using Spider.Invoicing.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Invoicing.API.Handlers.GetInvoices
{
    public class GetInvoicesQueryHandler
    {
        private const int DEFAULT_ELEMENTS_PER_PAGE = 25;

        private readonly InvoicingContext dbContext;

        public GetInvoicesQueryHandler(InvoicingContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public GetInvoicesResponse Handle(GetInvoicesQuery query)
        {
            var perPage = query.PerPage<1 ? DEFAULT_ELEMENTS_PER_PAGE : query.PerPage;

            var dbQuery = dbContext.Invoices;
            var invoices = dbQuery.OrderBy(x=>x.CreatedAt).Select(x => new Invoice()
             {
                 CreatedAt = x.CreatedAt,
                 GrossAmmount = x.GrossAmmount,
                 Id = x.InvoiceId,
                 InvoiceNumber = x.InvoiceNumber,
                 NetAmount = x.NetAmount,
                 VatAmount = x.VatAmount,
             }).Skip(query.Page * perPage).Take(perPage).ToList();

            var response = new GetInvoicesResponse()
            {
                Count = invoices.Count(),
                Result = invoices,
                Page = query.Page,
                TotalCount = invoices.Count,
                TotalPages = invoices.Count / perPage,
                IsSuccess = true,
            };
            return response;
        }
    }
}
