using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RichObject.Api.ApiModels;
using RichObject.Domain;

namespace RichObject.Api.Controllers
{
    [ApiController]
    public class CustomersV3Controller : Controller
    {
        private readonly ICustomerRepositoryV3 _customerRepository;
        private readonly Mapper _mapper;

        public CustomersV3Controller(ICustomerRepositoryV3 customerRepository,
            Mapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        
        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponse>> Get(Guid id)
        {
            var customerData = await _customerRepository.Get(id);
            var customer = Mapper.Map<CustomerV1>(customerData);
            var customerResponse = Mapper.Map<CustomerResponse>(customer);

            
            return Ok(customerResponse);
        }
    }
}