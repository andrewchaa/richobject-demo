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
    /// Transaction Scripts
    /// </summary>
    
    [ApiController]
    [Route("api/[controller]")]
    public class Customers4IController : Controller
    {
        private readonly Mediator _mediator;

        public Customers4IController(Mediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPut("{customerId}/currentAddress")]
        public async Task<ActionResult<Guid>> ChangeCurrentAddress([FromRoute]Guid customerId, 
            [FromBody] AddressRequest4I request)
        {
            // value objects validate their inputs
            var addressResult = Address4I.Create(Guid.NewGuid(), 
                request.HouseNoOrName,
                request.Street,
                request.City,
                request.County,
                request.PostCode,
                true);

            if (addressResult.Status == OperationStatus.ValidationFailure)
                return BadRequest(addressResult.ErrorMessages);

            // command handler owns the business logic that updates the customer's current address
            var response = await _mediator.Send(new ChangeCurrentAddressCommand4I(customerId,
                addressResult.Value));
            if (response.Status == OperationStatus.NotFound)
                return NotFound(customerId);

            return NoContent();
        }
    }
}