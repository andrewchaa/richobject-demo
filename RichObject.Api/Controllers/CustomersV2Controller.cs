using System;
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
            var customerResponse = new CustomerResponse
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Title = customer.Title,
                Addresses =  customer.Addresses.Select(a => new AddressResponse
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