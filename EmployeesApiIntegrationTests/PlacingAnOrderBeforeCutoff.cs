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
    public class PlacingAnOrderBeforeCutoff: IClassFixture<PlacingAnOrderBeforeCutoffContext>
    {
        public readonly HttpClient _client;

        public PlacingAnOrderBeforeCutoff(PlacingAnOrderBeforeCutoffContext factory)
        {
            _client = factory.CreateClient();
        }
        [Fact]
        public async Task ShipsSameDay()
        {
            var response = await _client.PostAsJsonAsync("/orders", new OrderRequest());

            var content = await response.Content.ReadAsAsync<OrderConfirmationResponse>();

            Assert.Equal(20, content.estimatedShipDate.Date.Day);
        }
    }

    public class PlacingAnOrderBeforeCutoffContext : CustomWebApplicationFactory<Startup>
    {
        public PlacingAnOrderBeforeCutoffContext()
        {
            var fakeSystemTime = new Mock<ISystemTime>();
            fakeSystemTime.Setup(m => m.GetCurrent()).Returns(
                new DateTime(1969, 4, 20, 11, 59, 59));
            AddTestDouble<ISystemTime>(fakeSystemTime.Object);

        }
    }
}
