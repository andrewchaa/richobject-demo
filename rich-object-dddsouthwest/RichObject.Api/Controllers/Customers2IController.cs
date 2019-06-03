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
    [Route("api/[controller]")]
    public class Customers2IController : Controller
    {
        private readonly Mediator _mediator;

        public Customers2IController(Mediator mediator)
        {
            _mediator = mediator;
        }
        
        // POST
        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] CustomerRequest2I customerRequest)
        {
            // from request DTO to command DTO
            var createCustomerCommand = Mapper.Map<CreateCustomerCommand2I>(customerRequest);
            
            // from command DTO to command handler response DTO
            var createCustomerCommandResponse = await _mediator.Send(createCustomerCommand);
            if (createCustomerCommandResponse.ErrorType == ErrorType.ValidationError)
                return BadRequest(createCustomerCommandResponse.ErrorMessages);

            if (createCustomerCommandResponse.ErrorType == ErrorType.Conflict)
            {
                // conversion from command response DTO to API response dto
                var customerConflictResponse = Mapper.Map<CreateCustomerApiResponse2I>(createCustomerCommandResponse);
                return Conflict(customerConflictResponse);
            }

            // conversion from command response DTO to API response dto
            var createCustomerApiResponse = Mapper.Map<CreateCustomerApiResponse2I>(createCustomerCommandResponse);
            return Ok(createCustomerApiResponse);
        }
    }
}