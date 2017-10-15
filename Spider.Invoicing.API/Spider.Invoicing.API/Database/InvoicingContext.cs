using Microsoft.EntityFrameworkCore;
using Spider.Invoicing.API.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Invoicing.API.Database
{
    public class InvoicingContext : DbContext
    {
        public InvoicingContext(DbContextOptions<InvoicingContext> options)
        : base(options)
        { }

        public DbSet<Invoice> Invoices { get; set; }
    }
}
