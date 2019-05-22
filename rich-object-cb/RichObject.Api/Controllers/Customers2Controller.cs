using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Validators;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RichObject.Api.ApiModels;
using RichObject.Api.Validators;
using RichObject.Domain.Commands;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Models;

namespace RichObject.Api.Controllers
{
    /// <summary>
    /// Introduce Domain Model and let Command wrap it
    /// Command Response DTO
    /// Use of Mapper
    /// Use of Validation Scripts
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class Customers2Controller : Controller
    {
        private readonly IMediator _mediator;

        public Customers2Controller(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        // POST
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerRequest request)
        {
            var validator = new CreateCustomerValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            var address = Address2.Create(request.Address.HouseNoOrName,
                request.Address.Street,
                request.Address.City,
                request.Address.County,
                request.Address.PostCode
            );

            var customer = Customer2.Create(request.CustomerId, 
                request.FirstName,
                request.LastName,
                request.MiddleName,
                request.Title,
                address,
                request.DateOfBirth,
                request.CountryOfBirth,
                request.IdDocumentType,
                request.IdDocumentNumber,
                request.VatNumber,
                request.VatCountry);

            // wrap customer domain model
            var createCustomerCommand = new CreateCustomerCommand2(customer);

            // command handler returns response that wraps domain model
            var response = await _mediator.Send(createCustomerCommand);

            if (response.Status == OperationStatus.ValidationFailure)
                return BadRequest(response.ErrorMessages);

            if (response.Status == OperationStatus.Conflict)
                return Conflict(response);

            return Ok(response.Value);
        }
    }
}