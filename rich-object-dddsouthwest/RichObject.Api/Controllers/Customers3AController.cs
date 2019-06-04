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
    public class Customers3AController : Controller
    {
        private readonly Mediator _mediator;

        public Customers3AController(Mediator mediator)
        {
            _mediator = mediator;
        }
        
        // POST
        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] CustomerRequest3A request)
        {
            // value objects validate their inputs
            var nameResult = CustomerName.Create(request.Title,
                request.FirstName,
                request.LastName);
            if (nameResult.Status == OperationStatus.ValidationFailure)
                return BadRequest(nameResult.ErrorMessages);

            var dobResult = Dob.Create(request.DateOfBirth);
            if (dobResult.Status == OperationStatus.ValidationFailure)
                return BadRequest(dobResult.ErrorMessages);

            var idDocumentResult = IdDocument.Create(request.IdDocumentType,
                request.IdDocumentNumber);
            if (idDocumentResult.Status == OperationStatus.ValidationFailure)
                return BadRequest(idDocumentResult.ErrorMessages);
            
            // convert request DTO to domain model
            var customer = new Customer3A(request.CustomerId,
                nameResult.Value,
                dobResult.Value,
                idDocumentResult.Value,
                request.Addresses.Select(a => new Address3A(a.HouseNoOrName,
                    a.Street,
                    a.City,
                    a.County,
                    a.PostCode,
                    a.CurrentAddress
                )));
            
            // command just wrap domain model
            var response = await _mediator.Send(new CreateCustomerCommand3A(customer));

            var apiResponse = new CreateCustomerApiResponse3A(response.Value);
            if (response.Status == OperationStatus.Conflict)
            {
                return Conflict(apiResponse);
            }

            return Created($"/customers/customer/{apiResponse.CustomerId}", apiResponse);
        }
    }
}