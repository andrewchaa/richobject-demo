using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RichObject.Api.ApiModels;
using RichObject.Domain;
using RichObject.Domain.Repositories;

namespace RichObject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class Customers1AController : Controller
    {
        private readonly ICustomerRepository1A _customerRepository;

        public Customers1AController(ICustomerRepository1A customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCustomerResponseAns1>> Get(Guid id)
        {
            var customer = await _customerRepository.Get(id);

            var currentAddress = customer.Addresses.Single(a => a.CurrentAddress);
            var customerResponse = new GetCustomerResponseAns1
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Title = customer.Title,
                CurrentAddress = new AddressResponse 
                {
                    HouseNoOrName = currentAddress.HouseNoOrName,
                    Street = currentAddress.Street,
                    City = currentAddress.City,
                    County = currentAddress.County,
                    PostCode = currentAddress.PostCode
                }, 
                PastAddresses =  customer.Addresses.Where(a => !a.CurrentAddress)
                    .Select(a => new AddressResponse
                {
                    HouseNoOrName = a.HouseNoOrName,
                    Street = a.Street,
                    City = a.City,
                    County = a.County,
                    PostCode = a.PostCode
                }),
                DateOfBirth = customer.DateOfBirth,
                IdDocumentType = customer.IdDocumentType,
                IdDocumentNumber = customer.IdDocumentNumber
            };
            
            return Ok(customerResponse);
        }
    }
}