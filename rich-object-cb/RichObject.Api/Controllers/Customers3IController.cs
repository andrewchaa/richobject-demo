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
    public class Customers3IController : Controller
    {
        private readonly Mediator _mediator;

        public Customers3IController(Mediator mediator)
        {
            _mediator = mediator;
        }
        
        // POST
        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] CustomerRequestIss3 customerRequest)
        {
            // from request DTO to command DTO
            var createCustomerCommand = Mapper.Map<CreateCustomerCommand3I>(customerRequest);
            
            // from command DTO to command handler response DTO
            var response = await _mediator.Send(createCustomerCommand);
            if (response.ErrorType == ErrorType.ValidationError)
                return BadRequest(response.ErrorMessages);

            if (response.ErrorType == ErrorType.Conflict)
            {
                // conversion from command response DTO to API response dto
                var customerConflictResponse = Mapper.Map<CreateCustomerResponseIss3>(response);
                return Conflict(customerConflictResponse);
            }

            // conversion from command response DTO to API response dto
            var customerResponse = Mapper.Map<CreateCustomerResponseIss3>(response);
            return Ok(customerResponse);
        }
    }
}