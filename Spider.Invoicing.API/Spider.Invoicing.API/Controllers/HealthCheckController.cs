using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spider.Invoicing.API.Models;

namespace Spider.Invoicing.API.Controllers
{
    [Route("")]
    public class HealthCheckController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Ok");
        }
    }
}
