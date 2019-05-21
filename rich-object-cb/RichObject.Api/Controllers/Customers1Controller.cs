using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RichObject.Api.ApiModels;
using RichObject.Domain.Commands;

namespace RichObject.Api.Controllers
{
    /// <summary>
    /// Request DTO
    /// Command DTO
    /// Command Response DTO
    /// Use of Mapper
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

    public class CreateCustomerValidator : AbstractValidator<CreateCustomerRequest1>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.CountryOfBirth).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.IdDocumentNumber).NotEmpty();
            RuleFor(x => x.IdDocumentType).NotEmpty();
            RuleFor(x => x.VatCountry).NotEmpty();
            RuleFor(x => x.VatNumber).NotEmpty();
        }
    }
}