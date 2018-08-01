using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Spider.Invoicing.API.Database
{
    public class InvoicingContextFactory : IDesignTimeDbContextFactory<InvoicingContext>
    {
        public InvoicingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InvoicingContext>();
            optionsBuilder.UseSqlServer("Server=spiderdev.ml;Database=Invoicing;Integrated Security=False; user id=sa; password=xk4GGuwrwAYgh9zm;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new InvoicingContext(optionsBuilder.Options);
        }
    }
}
