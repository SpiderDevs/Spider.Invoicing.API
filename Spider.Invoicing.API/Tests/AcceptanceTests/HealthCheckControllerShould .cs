using System;
using System.Net;
using Xunit;

namespace AcceptanceTests
{
    public class HealthCheckControllerShould : TestBase
    {
        [Fact]
        public void ReturnOk()
        {
            var response = client.GetAsync("").Result;
            var responseMessage = response.Content.ReadAsStringAsync().Result;

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Ok", responseMessage);
        }
    }
}
