using System;
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
    /// Complex validation into Command Handler
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class Customers4Controller : Controller
    {
        private readonly IMediator _mediator;

        public Customers4Controller(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("{customerId}/currentAddress")]
        public async Task<IActionResult> ChangeCurrentAddress(Guid customerId,
            [FromBody] AddressRequest request)
        {

            var addressResult = Address4.Create(request.HouseNoOrName,
                request.Street,
                request.City,
                request.County,
                request.PostCode
            );

            if (addressResult.Status == OperationStatus.ValidationFailure)
                return BadRequest(addressResult.ErrorMessages);

            var addressIdResult = await _mediator.Send(new ChangeCustomerAddressCommand4(customerId,
                addressResult.Value));

            if (addressIdResult == OperationResult<Unit>.NotFound())
            {
                return NotFound($"The {nameof(customerId)}: {customerId} doesn't exist.");
            }

            return Created(
                new Uri($"api/v1/customers/{customerId}/addresses/{addressIdResult.Value}", UriKind.Relative),
                new { });
        }


        // POST
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerRequest request)
        {
            var validator = new CreateCustomerValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            var addressResult = Address3.Create(request.Address.HouseNoOrName,
                request.Address.Street,
                request.Address.City,
                request.Address.County,
                request.Address.PostCode
            );

            if (addressResult.Status == OperationStatus.ValidationFailure)
                return BadRequest(addressResult.ErrorMessages);

            var customerResult = Customer3.Create(request.CustomerId, 
                request.FirstName,
                request.LastName,
                request.MiddleName,
                request.Title,
                addressResult.Value,
                request.DateOfBirth,
                request.CountryOfBirth,
                request.IdDocumentType,
                request.IdDocumentNumber,
                request.VatNumber,
                request.VatCountry);

            if (customerResult.Status == OperationStatus.ValidationFailure)
                return BadRequest(customerResult.ErrorMessages);


            // command handler returns response that wraps domain model
            var response = await _mediator.Send(new CreateCustomerCommand3(
                customerResult.Value));

            if (response.Status == OperationStatus.ValidationFailure)
                return BadRequest(response.ErrorMessages);

            if (response.Status == OperationStatus.Conflict)
                return Conflict(response);

            return Ok(response.Value);
        }
    }
}