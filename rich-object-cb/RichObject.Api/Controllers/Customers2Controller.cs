using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RichObject.Api.ApiModels;
using RichObject.Domain.Commands;

namespace RichObject.Api.Controllers
{
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
        public async Task<IActionResult> Post([FromBody] CustomerRequest1 customerRequest)
        {
            // convert request DTO to command DTO
            var createCustomerCommand = Mapper.Map<CreateCustomerCommand1>(customerRequest);

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