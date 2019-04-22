using System;
using Microsoft.AspNetCore.Mvc;
using RichObject.Domain;

namespace RichObject.Api.Controllers
{
    [ApiController]
    public class CustomersV1Controller : Controller
    {
        private readonly ICustomerRepositoryV1 _customerRepository;

        public CustomersV1Controller(ICustomerRepositoryV1 customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        // GET
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var customer = _customerRepository.Get(id);
            return Ok(customer);
        }
    }

}