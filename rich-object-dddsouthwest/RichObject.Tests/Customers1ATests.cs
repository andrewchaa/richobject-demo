using System;
using System.Collections.Generic;
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
using RichObject.Domain.Values;
using Xunit;

namespace RichObject.Tests
{
    public class Customers1ATests : IClassFixture<TestApiFactory>
    {
        private readonly TestApiFactory _factory;
        private readonly HttpClient _client;

        public Customers1ATests(TestApiFactory factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();

            var firstName = "firstName";
            var lastName = "lastName";
            var title = "title";
            var dateOfBirth = new DateTime(2000, 1, 1);
            var idDocumentType = "Passport";
            var idDocumentNumber = "101010";
            var addresses = new List<Address1A>
            {
                new Address1A("4",
                    "Devonshire Square",
                    "London",
                    "",
                    "WC1X",
                    true)
            };
            var customerId = Guid.NewGuid();
            _factory.CustomerRepository1A.Setup(c => c.Get(It.IsAny<Guid>()))
                .ReturnsAsync(new Customer1A(customerId,
                    firstName,
                    lastName,
                    title,
                    dateOfBirth,
                    idDocumentType,
                    idDocumentNumber,
                    addresses
                    ));

        }
        
        [Fact]
        public async Task Should_get_the_customer_by_id()
        {
            var response = await _client.GetAsync($"/api/customers1a/{Guid.NewGuid()}");
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}