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
    /// Answer to Local / Boundary DTOs Demo
    /// </summary>
    
    [ApiController]
    public class Customers3AnsController : Controller
    {
        private readonly Mediator _mediator;

        public Customers3AnsController(Mediator mediator)
        {
            _mediator = mediator;
        }
        
        // POST
        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] CustomerRequestAns3 customerRequest)
        {
            // convert request DTO to domain model
            var customer = new Customer3Ans(customerRequest.FirstName,
                customerRequest.LastName,
                customerRequest.Title,
                customerRequest.DateOfBirth,
                customerRequest.IdDocumentType,
                customerRequest.IdDocumentNumber,
                customerRequest.Addresses.Select(a => new AddressAns3(a.HouseNoOrName,
                    a.Street,
                    a.City,
                    a.County,
                    a.PostCode,
                    a.CurrentAddress
                    )));
            
            // command just wrap domain model
            var createCustomerCommand = new CreateCustomerCommandAns3(customer);
            
            // command handler returns response that wraps domain model
            var response = await _mediator.Send(createCustomerCommand);
            if (response.Result == OperationResult.ValidationFailure)
                return BadRequest(response.ErrorMessages);

            var customerApiResponse = Mapper.Map<CreateCustomerResponseAns3>(response.Value);
            if (response.Result == OperationResult.Conflict)
            {
                return Conflict(customerApiResponse);
            }

            return Ok(customerApiResponse);
        }
    }
}