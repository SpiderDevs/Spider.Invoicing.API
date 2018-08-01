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
using System.IdentityModel.Tokens.Jwt;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using Serilog;
using Spider.Invoicing.API.Models;

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
            services.AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog(dispose: true)
                    .AddFile("Logs/spider-invoicing-api-{Date}.txt", isJson: true));

            services.AddMvcCore()
                  .AddAuthorization()
                  .AddJsonFormatters()
                  .AddApiExplorer();

            services.AddDbContext<InvoicingContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("InvoicingConnection")));

            services.AddTransient<GetInvoicesQueryHandler, GetInvoicesQueryHandler>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            SetAuthenticationMethod(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Spider invoicing API", Version = "v1" });
                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "Spider.Invoicing.API.xml");
                c.IncludeXmlComments(filePath);
            });
        }

        private void SetAuthenticationMethod(IServiceCollection services)
        {
            var domainSettings = new DomainSettings();
            Configuration.GetSection("DomainSettings").Bind(domainSettings);

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = domainSettings.IdentityServer;
                    options.RequireHttpsMetadata = false;

                    options.ApiSecret = "secret";
                    options.ApiName = "customAPI";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, InvoicingContext dbContext)
        {
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();
            
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Spider invoicing API v1");
            });

            dbContext.Database.Migrate();
            //TODO: only for tests
            InitDbTestData(dbContext);
        }


        private void InitDbTestData(InvoicingContext dbContext)
        {
            if (!dbContext.Invoices.Any())
            {
                var fakeInvoices = new List<Invoice>()
                {
                    new Invoice()
                    {
                        CreatedAt = DateTime.Now.AddDays(-3),
                        GrossAmmount =1234.12m,
                        InvoiceNumber = "241/04/2017/PKS",
                        NetAmount = 2312.3m,
                        VatAmount = 327.1m,
                    },
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
                    }
                };

                dbContext.Invoices.AddRange(fakeInvoices);
                dbContext.SaveChanges();
            }
        }

       

    }
}
