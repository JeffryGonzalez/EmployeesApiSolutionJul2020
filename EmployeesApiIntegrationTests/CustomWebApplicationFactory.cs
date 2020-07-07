using EmployeesApi.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeesApiIntegrationTests
{
    public class CustomWebApplicationFactory<TStartup> :
        WebApplicationFactory<TStartup> where TStartup : class
    {
        public DateTime SystemTimeToUse { get; set; }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d =>
                d.ServiceType == typeof(ISystemTime));
                if(descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddSingleton<ISystemTime, TestingSystemTime>();
                var sp = services.BuildServiceProvider();
                using(var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var st = scopedServices.GetRequiredService<ISystemTime>();
                    ((TestingSystemTime)st).TimeToReturn = SystemTimeToUse;
                }
            });
        }
    }

    public class TestingSystemTime : ISystemTime
    {
        public DateTime TimeToReturn { get; set; }

        public DateTime GetCreatedAt()
        {
            return DateTime.Now;
        }

        public DateTime GetCurrent()
        {
            return new DateTime(1969, 4, 20, 11, 59, 59);
        }
    }
}
