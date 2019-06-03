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
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Models;
using RichObject.Domain.Repositories;
using RichObject.Domain.Values;

namespace RichObject.Api.Controllers
{
    /// <summary>
    /// Validation Scripts
    /// </summary>
    
    [ApiController]
    [Route("api/[controller]")]
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
            if (nameResponse.Status == OperationStatus.ValidationFailure)
                return BadRequest(nameResponse.ErrorMessages);

            var dobResponse = Dob.Create(request.DateOfBirth);
            if (dobResponse.Status == OperationStatus.ValidationFailure)
                return BadRequest(dobResponse.ErrorMessages);

            var idDocumentResponse = IdDocument.Create(request.IdDocumentType,
                request.IdDocumentNumber);
            if (idDocumentResponse.Status == OperationStatus.ValidationFailure)
                return BadRequest(idDocumentResponse.ErrorMessages);
            
            // convert request DTO to domain model
            var customer = new Customer4A(request.CustomerId,
                nameResponse.Value,
                dobResponse.Value,
                idDocumentResponse.Value,
                request.Addresses.Select(a => new Address3A(a.HouseNoOrName,
                    a.Street,
                    a.City,
                    a.County,
                    a.PostCode,
                    a.CurrentAddress
                )));
            
            // command just wrap domain model
            var response = await _mediator.Send(new CreateCustomerCommand4A(customer));

            var apiResponse = Mapper.Map<CreateCustomerResponse2A>(response.Value);
            if (response.Status == OperationStatus.Conflict)
            {
                return Conflict(apiResponse);
            }

            return Created($"/customers/customer/{apiResponse.CustomerId}", apiResponse);
        }
    }
}