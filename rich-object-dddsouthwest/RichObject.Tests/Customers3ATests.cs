using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using Newtonsoft.Json;
using RichObject.Api;
using RichObject.Api.ApiModels;
using RichObject.Domain.Models;
using RichObject.Domain.Repositories;
using RichObject.Domain.Values;
using Xunit;

namespace RichObject.Tests
{
    public class Customers3ATests : IClassFixture<TestApiFactory>
    {
        private readonly TestApiFactory _factory;
        private readonly HttpClient _client;

        public Customers3ATests(TestApiFactory factory)
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
        public async Task Should_creat_a_new_customer()
        {
            var request = new CreateCustomerRequest2A
            {
                FirstName = "firstName",
                LastName = "lastName",
                Title = "title",
                Addresses = new List<AddressRequestAns3>
                {
                    new AddressRequestAns3
                    {
                        City = "city",
                        County = "county",
                        CurrentAddress = true,
                        HouseNoOrName = "4",
                        PostCode = "E4",
                        Street = "Liverpool Street"
                    }
                },
                DateOfBirth = new DateTime(2000, 1, 1),
                IdDocumentType = "Passport",
                IdDocumentNumber = "1010101"

            };
            var response = await _client.PostAsync($"/api/customers3a",  
                CreateJsonContent(request));
            var content = await response.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        
        private static HttpContent CreateJsonContent<T>(T body) => 
            new StringContent(JsonConvert.SerializeObject(body), 
                Encoding.UTF8, 
                "application/json");
    }
}