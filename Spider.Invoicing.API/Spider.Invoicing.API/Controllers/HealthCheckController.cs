using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Spider.Invoicing.API.Models;

namespace Spider.Invoicing.API.Controllers
{
    [Route("")]
    public class HealthCheckController : Controller
    {
        private readonly ILogger<InvoicingController> log;

        public HealthCheckController(ILogger<InvoicingController> log)
        {
            this.log = log;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            string displayableVersion = $"{version}";

            log.LogInformation($"Called Health Check. Api version {displayableVersion}");
            return Ok($"Ok. Api version {displayableVersion}");
        }
    }
}
