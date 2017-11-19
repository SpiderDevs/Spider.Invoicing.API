using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Spider.Invoicing.API;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AcceptanceTests
{
    public class TestBase : IDisposable
    {
        protected readonly TestServer server;
        protected readonly HttpClient client;

        public TestBase()
        {
            server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            client = server.CreateClient();
        }

        public void Dispose()
        {
            server.Dispose();
            client.Dispose();
        }
    }
}
