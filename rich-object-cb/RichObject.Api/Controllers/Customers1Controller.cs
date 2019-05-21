using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Validators;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RichObject.Api.ApiModels;
using RichObject.Api.Validators;
using RichObject.Domain.Commands;

namespace RichObject.Api.Controllers
{
    /// <summary>
    /// Request DTO
    /// Command DTO
    /// Command Response DTO
    /// Use of Mapper
    /// Use of Validation Scripts
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class Customers1Controller : Controller
    {
        private readonly IMediator _mediator;

        public Customers1Controller(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        // POST
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerRequest1 request)
        {
            var validator = new CreateCustomerValidator();

            // convert request DTO to command DTO
            var createCustomerCommand = Mapper.Map<CreateCustomerCommand1>(request);

            // command handler returns response that wraps domain model
            var createCustomerCommandResponse = await _mediator.Send(createCustomerCommand);
            
            if (createCustomerCommandResponse.Result == OperationStatus.ValidationFailure)
                return BadRequest(createCustomerCommandResponse.ErrorMessages);

            if (createCustomerCommandResponse.Result == OperationStatus.Conflict)
                return Conflict(createCustomerCommandResponse);

            return Ok(createCustomerCommandResponse.CustomerId);
        }
    }
}