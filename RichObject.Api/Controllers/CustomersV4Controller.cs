using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RichObject.Api.ApiModels;
using RichObject.Domain;
using RichObject.Domain.Commands;
using RichObject.Domain.Models;
using RichObject.Domain.Repositories;

namespace RichObject.Api.Controllers
{
    /// <summary>
    /// Local / Boundary DTOs Demo
    /// </summary>
    
    [ApiController]
    public class CustomersV4Controller : Controller
    {
        private readonly ICustomerRepositoryV3 _customerRepository;
        private readonly Mediator _mediator;

        public CustomersV4Controller(ICustomerRepositoryV3 customerRepository,
            Mediator mediator)
        {
            _customerRepository = customerRepository;
            _mediator = mediator;
        }
        
        // POST
        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] CustomerRequestV4 customerRequest)
        {
            // command DTO
            var createCustomerCommand = Mapper.Map<CreateCustomerCommandV4>(customerRequest);
            
            // response DTO
            var response = await _mediator.Send(createCustomerCommand);
            
            if (!response.Success)
                return BadRequest(response.ErrorMessages);

            // duplicated properties across DTOs
            return Ok(new CreateCustomerResponseV4
            {
                CustomerId = response.CustomerId,
                FirstName = response.FirstName,
                LastName = response.LastName,
                Title = response.Title
            });
        }
    }
}