using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RichObject.Api.ApiModels;
using RichObject.Domain.Commands;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Models;
using RichObject.Domain.Queries;

namespace RichObject.Api.Controllers
{
    /// <summary>
    /// Answer to Local / Boundary DTOs Demo
    /// </summary>
    
    [ApiController]
    [Route("api/[controller]")]
    public class Customers2AController : Controller
    {
        private readonly IMediator _mediator;

        public Customers2AController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCustomerApiResponse2A>> Get(Guid id)
        {
            var queryResult = await _mediator.Send(new GetCustomerQuery2A(id));
            if (queryResult.Status == OperationStatus.NotFound)
                return NotFound();

            var apiResponse = new GetCustomerApiResponse2A(queryResult.Value);
            return Ok(apiResponse);
        }

        
        // POST
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerRequest2A createCustomerRequest)
        {
            // convert request DTO to domain model
            var customer = new Customer2A(createCustomerRequest.FirstName,
                createCustomerRequest.LastName,
                createCustomerRequest.Title,
                createCustomerRequest.DateOfBirth,
                createCustomerRequest.IdDocumentType,
                createCustomerRequest.IdDocumentNumber,
                createCustomerRequest.Addresses.Select(a => new Address2A(a.HouseNoOrName,
                    a.Street,
                    a.City,
                    a.County,
                    a.PostCode,
                    a.CurrentAddress
                    )));
            
            // command just wrap domain model
            var createCustomerCommand = new CreateCustomerCommand2A(customer);
            
            // command handler returns response that wraps domain model
            var response = await _mediator.Send(createCustomerCommand);
            if (response.Status == OperationStatus.ValidationFailure)
                return BadRequest(response.ErrorMessages);

            var customerApiResponse = new CreateCustomerApiResponse2A(response.Value);
            if (response.Status == OperationStatus.Conflict)
            {
                return Conflict(customerApiResponse);
            }

            return Ok(customerApiResponse);
        }
    }
}