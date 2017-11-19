using System;
using System.Net;
using Xunit;

namespace AcceptanceTests
{
    public class InvoicingControllerShould : TestBase
    {
        [Fact]
        public void ReturnUnauthorised_WhenUserIsNotLogged()
        {
            var response = client.GetAsync("api/Invoicing");
            Assert.Equal(HttpStatusCode.Unauthorized, response.Result.StatusCode);
        }
    }
}
