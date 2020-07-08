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

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                foreach (var kvp in deps)
                {
                    var descriptor = services.SingleOrDefault(d =>
                        d.ServiceType == kvp.Key

                    );
                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }
                    services.AddSingleton(kvp.Key, kvp.Value);

                }
                var sp = services.BuildServiceProvider();
                using var scope = sp.CreateScope();
                HandleScopedServices(scope);

            });
        }

        protected virtual void HandleScopedServices(IServiceScope scope)
        {

        }

        protected Dictionary<Type, object> deps = new Dictionary<Type, object>();
        protected void AddTestDouble<TService>(TService dep)
        {
            deps.Add(typeof(TService), dep);
        }
    }
}
