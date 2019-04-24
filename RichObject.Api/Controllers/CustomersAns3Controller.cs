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
    public class CustomersAns3Controller : Controller
    {
        private readonly Mediator _mediator;

        public CustomersAns3Controller(Mediator mediator)
        {
            _mediator = mediator;
        }
        
        // POST
        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] CustomerRequestAns3 customerRequest)
        {
            // convert request DTO to domain model
            var customer = new CustomerAns3(customerRequest.FirstName,
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
            
            // command handler returns response that wraps domaon model
            var response = await _mediator.Send(createCustomerCommand);
//            if (response.ErrorType == ErrorType.ValidationError)
//                return BadRequest(response.ErrorMessages);
//
//            if (response.ErrorType == ErrorType.Conflict)
//            {
//                // conversion from command response DTO to API response dto
//                var customerConflictResponse = Mapper.Map<CreateCustomerResponseIss3>(response);
//                return Conflict(customerConflictResponse);
//            }

            // conversion from command response DTO to API response dto
            var customerResponse = Mapper.Map<CreateCustomerResponseIss3>(response);
            return Ok(customerResponse);
        }
    }
}