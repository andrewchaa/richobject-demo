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
    public class CustomersV3Controller : Controller
    {
        private readonly ICustomerRepositoryV3 _customerRepository;

        public CustomersV3Controller(ICustomerRepositoryV3 customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCustomerResponseV2>> Get(Guid id)
        {
            var customerData = await _customerRepository.Get(id);
            var customer = Mapper.Map<CustomerV1>(customerData);
            var customerResponse = Mapper.Map<GetCustomerResponseV2>(customer);

            
            return Ok(customerResponse);
        }
    }
}