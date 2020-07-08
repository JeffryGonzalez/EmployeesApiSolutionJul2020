using EmployeesApi;
using EmployeesApi.Services;
using EmployeesApiIntegrationTests.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeesApiIntegrationTests
{
    public class PlacingAnOrderAfterCutoff : IClassFixture<PlacingAnOrderAfterCutoffContext>
    {

        private readonly HttpClient _client;
        public PlacingAnOrderAfterCutoff(PlacingAnOrderAfterCutoffContext factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ShipsNextDay()
        {
            var response = await _client.PostAsJsonAsync("/orders", new OrderRequest());

            var content = await response.Content.ReadAsAsync<OrderConfirmationResponse>();

            Assert.Equal(21, content.estimatedShipDate.Date.Day);
        }
    }

    public class PlacingAnOrderAfterCutoffContext : CustomWebApplicationFactory<Startup>
    {
        public PlacingAnOrderAfterCutoffContext()
        {
            var fakeSystemTime = new Mock<ISystemTime>();
            fakeSystemTime.Setup(m => m.GetCurrent()).Returns(
                new DateTime(1969, 4, 20, 12, 00, 00));
            AddTestDouble<ISystemTime>(fakeSystemTime.Object);

        }
    }
}
