using System;
using Microsoft.AspNetCore.Mvc;
using RichObject.Domain;
using RichObject.Domain.Repositories;

namespace RichObject.Api.Controllers
{
    [ApiController]
    public class CustomersIss1Controller : Controller
    {
        private readonly ICustomerRepositoryIss1 _customerRepository;

        public CustomersIss1Controller(ICustomerRepositoryIss1 customerRepository)
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