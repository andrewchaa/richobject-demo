using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using RichObject.Api;
using RichObject.Domain.Models;
using RichObject.Domain.Repositories;
using Xunit;

namespace RichObject.Tests
{
    public class Customers1ITests : IClassFixture<TestApiFactory>
    {
        private readonly TestApiFactory _factory;
        private readonly HttpClient _client;

        public Customers1ITests(TestApiFactory factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();

            _factory.CustomerRepository1I.Setup(c => c.Get(It.IsAny<Guid>()))
                .ReturnsAsync(new Customer1I());

        }
        
        [Fact]
        public async Task Should_get_the_customer_by_id()
        {
            var response = await _client.GetAsync($"/api/customers1i/{Guid.NewGuid()}");
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}