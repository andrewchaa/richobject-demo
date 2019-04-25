using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using RichObject.Api;
using RichObject.Domain.Models;
using RichObject.Domain.Repositories;
using Xunit;

namespace RichObject.Tests
{
    public class Customers1ITests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;

        public Customers1ITests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;

            var customerRepository1I = new Mock<ICustomerRepository1I>();
            customerRepository1I.Setup(c => c.Get(It.IsAny<Guid>()))
                .ReturnsAsync(new Customer1I());


            _factory.WithWebHostBuilder(b => b.ConfigureServices(services =>
                {
                    services.AddTransient(s => customerRepository1I.Object);
                }
            ));
            
            _client = _factory.CreateClient();
            
        }
        
        [Fact]
        public async Task Test1()
        {
            var response = await _client.GetAsync($"/api/customers1i/{Guid.NewGuid()}");
            
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    }
}