using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RichObject.Api;
using RichObject.Domain.Repositories;

namespace RichObject.Tests
{
    public class TestApiFactory : WebApplicationFactory<Startup>
    {
//        public Mock<ICustomerRepository1I> CustomerRepository1I { get; } = new Mock<ICustomerRepository1I>();
//        public Mock<ICustomerRepository1A> CustomerRepository1A { get; } = new Mock<ICustomerRepository1A>();

        
        protected override IWebHostBuilder CreateWebHostBuilder() => new WebHostBuilder();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment(
                    Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development")
                .UseStartup<Startup>();

            builder.ConfigureTestServices(services =>
            {
//                services.AddTransient(s => CustomerRepository1I.Object);
//                services.AddTransient(s => CustomerRepository1A.Object);
                
            });
        }
    }
}