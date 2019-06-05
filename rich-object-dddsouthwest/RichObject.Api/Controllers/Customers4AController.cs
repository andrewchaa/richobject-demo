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
    [ApiController]
    [Route("api/[controller]")]
    public class Customers4AController : Controller
    {
        private readonly Mediator _mediator;

        public Customers4AController(Mediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPut("{customerId}/currentAddress")]
        public async Task<IActionResult> Put([FromRoute]Guid customerId, 
            [FromBody] AddressRequest4A request)
        {
            // value objects validate their inputs
            var addressResult = Address4A.Create(Guid.NewGuid(), 
                request.HouseNoOrName,
                request.Street,
                request.City,
                request.County,
                request.PostCode,
                true);

            if (addressResult.Status == OperationStatus.ValidationFailure)
                return BadRequest(addressResult.ErrorMessages);

            // command handler owns the business logic that updates the customer's current address
            var response = await _mediator.Send(new ChangeCurrentAddressCommand4A(customerId,
                addressResult.Value));
            if (response.Status == OperationStatus.NotFound)
                return NotFound(customerId);

            return NoContent();
        }
    }
}