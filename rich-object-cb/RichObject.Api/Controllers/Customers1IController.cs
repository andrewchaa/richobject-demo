using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RichObject.Domain;
using RichObject.Domain.Models;
using RichObject.Domain.Repositories;

namespace RichObject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Customers1IController : Controller
    {
        private readonly ICustomerRepository1I _customerRepository;

        public Customers1IController(ICustomerRepository1I customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer1I>> Get(Guid id)
        {
            var customer = await _customerRepository.Get(id);
            return Ok(customer);
        }
    }

}