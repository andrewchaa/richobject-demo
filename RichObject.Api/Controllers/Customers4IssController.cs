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

namespace RichObject.Api.Controllers
{
    /// <summary>
    /// Validation Scripts
    /// </summary>
    
    [ApiController]
    public class Customers4IssController : Controller
    {
        private readonly Mediator _mediator;

        public Customers4IssController(Mediator mediator)
        {
            _mediator = mediator;
        }
        
        // POST
        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] CustomerRequest4Iss request)
        {
            // validation script
            var errorMessage = new List<string>();
            if (string.IsNullOrEmpty(request.FirstName)) 
                errorMessage.Add($"{nameof(request.FirstName)} is empty");
            if (string.IsNullOrEmpty(request.LastName)) 
                errorMessage.Add($"{nameof(request.LastName)} is empty");
            if (string.IsNullOrEmpty(request.Title)) 
                errorMessage.Add($"{nameof(request.Title)} is empty");

            var age = DateTime.Today.Year - request.DateOfBirth.Year;
            if (request.DateOfBirth.Date > DateTime.Today.AddYears(-age)) age--;
            if (age < 18)
                errorMessage.Add($"The applicant's age must be at least 18");
            
            
            // convert request DTO to domain model
            var customer = new Customer4Iss(request.FirstName,
                request.LastName,
                request.Title,
                request.DateOfBirth,
                request.IdDocumentType,
                request.IdDocumentNumber,
                request.Addresses.Select(a => new AddressAns3(a.HouseNoOrName,
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
        }
    }
}