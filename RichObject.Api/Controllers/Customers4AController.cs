using System;
using System.Collections.Generic;
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
using RichObject.Domain.Values;

namespace RichObject.Api.Controllers
{
    /// <summary>
    /// Validation Scripts
    /// </summary>
    
    [ApiController]
    public class Customers4AController : Controller
    {
        private readonly Mediator _mediator;

        public Customers4AController(Mediator mediator)
        {
            _mediator = mediator;
        }
        
        // POST
        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] CustomerRequest4A request)
        {
            // value objects validate their inputs
            var nameResponse = CustomerName.Create(request.Title,
                request.FirstName,
                request.LastName);
            if (nameResponse.Result == OperationResult.ValidationFailure)
                return BadRequest(nameResponse.ErrorMessages);

            var dobResponse = Dob.Create(request.DateOfBirth);
            if (dobResponse.Result == OperationResult.ValidationFailure)
                return BadRequest(dobResponse.ErrorMessages);

            var idDocumentResponse = IdDocument.Create(request.IdDocumentType,
                request.IdDocumentNumber);
            if (idDocumentResponse.Result == OperationResult.ValidationFailure)
                return BadRequest(idDocumentResponse.ErrorMessages);
            
            // convert request DTO to domain model
            var customer = new Customer4A(nameResponse.Value,
                dobResponse.Value,
                idDocumentResponse.Value,
                request.Addresses.Select(a => new AddressAns3(a.HouseNoOrName,
                    a.Street,
                    a.City,
                    a.County,
                    a.PostCode,
                    a.CurrentAddress
                )));
            
            // command just wrap domain model
            var createCustomerCommand = new CreateCustomerCommand4A(customer);
            
            // command handler returns response that wraps domain model
            var response = await _mediator.Send(createCustomerCommand);
            if (response.Result == OperationResult.ValidationFailure)
                return BadRequest(response.ErrorMessages);

            var customerApiResponse = Mapper.Map<CreateCustomerResponseAns3>(response.Value);
            if (response.Result == OperationResult.Conflict)
            {
                return Conflict(customerApiResponse);
            }

            return Created($"/customers/customer/{customerApiResponse.CustomerId}", customerApiResponse);
        }
    }
}