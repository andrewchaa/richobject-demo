using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RichObject.Api.ApiModels;
using RichObject.Domain;

namespace RichObject.Api.Controllers
{
    [ApiController]
    public class CustomersV2Controller : Controller
    {
        private readonly ICustomerRepositoryV2 _customerRepository;

        public CustomersV2Controller(ICustomerRepositoryV2 customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponse>> Get(Guid id)
        {
            var customer = await _customerRepository.Get(id);

            var currentAddress = customer.Addresses.Single(a => a.CurrentAddress);
            var customerResponse = new CustomerResponse
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Title = customer.Title,
                CurrentAddress = new AddressResponse 
                {
                    HouseNoOrName = a.HouseNoOrName,
                    Street = a.Street,
                    City = a.City,
                    County = a.County,
                    PostCode = a.PostCode
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
    
    public class CustomerResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public IEnumerable<AddressResponse> PastAddresses { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNumber { get; set; }
        public AddressResponse CurrentAddress { get; set; }
    }

}