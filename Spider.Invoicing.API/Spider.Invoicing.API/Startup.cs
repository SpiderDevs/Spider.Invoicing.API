using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Spider.Invoicing.API.Database;
using Microsoft.EntityFrameworkCore;
using Spider.Invoicing.API.Handlers.GetInvoices;
using Spider.Invoicing.API.Database.Models;

namespace Spider.Invoicing.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InvoicingContext>(options =>
                 options.UseInMemoryDatabase("Test_InvoicingDb"));

            //TODO: Add autofac
            services.AddTransient<GetInvoicesQueryHandler, GetInvoicesQueryHandler>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, InvoicingContext dbContext)
        {
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            

            //TODO: only for tests
            InitDbTestData(dbContext);
        }


        private void InitDbTestData(InvoicingContext dbContext)
        {
            var fakeInvoices = new List<Invoice>()
            {
                new Invoice()
                {
                    CreatedAt = DateTime.Now.AddDays(-2),
                    GrossAmmount = 100,
                    InvoiceNumber = "241/04/2017/PKS",
                    NetAmount = 81,
                    VatAmount = 19,
                },
                 new Invoice()
                {
                    CreatedAt = DateTime.Now.AddDays(-1),
                    GrossAmmount = 120,
                    InvoiceNumber = "242/04/2017/PKS",
                    NetAmount = 98,
                    VatAmount = 22,
                },
                  new Invoice()
                {
                    CreatedAt = DateTime.Now.AddDays(0),
                    GrossAmmount = 65,
                    InvoiceNumber = "241/04/2017/PKS",
                    NetAmount = 58,
                    VatAmount = 7,
                },
            };

            dbContext.Invoices.AddRange(fakeInvoices);
            dbContext.SaveChanges();
        }


    }
}
