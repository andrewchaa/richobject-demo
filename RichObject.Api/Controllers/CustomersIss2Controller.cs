using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RichObject.Api.ApiModels;
using RichObject.Domain;
using RichObject.Domain.Models;
using RichObject.Domain.Repositories;

namespace RichObject.Api.Controllers
{
    [ApiController]
    public class CustomersIss2Controller : Controller
    {
        private readonly ICustomerRepositoryIss2 _customerRepository;

        public CustomersIss2Controller(ICustomerRepositoryIss2 customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCustomerResponseAns1>> Get(Guid id)
        {
            var customerData = await _customerRepository.Get(id);
            
            // To use mapper, you leave public setters to your domain models
            // Thus, every model becomes DTO
            var customer = Mapper.Map<CustomerIss2>(customerData);
            
            var customerResponse = Mapper.Map<GetCustomerResponseIss2>(customer);
            
            return Ok(customerResponse);
        }
    }
}