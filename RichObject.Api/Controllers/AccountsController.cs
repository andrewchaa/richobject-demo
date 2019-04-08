using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RichObject.Api.Controllers
{
    [Route("api/v1/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{accountId}")]
        public async Task<ActionResult<AccountResponse>> Get(Guid accountId)
        {
            var queryResponse = await _mediator.Send(new GetAccountDetailsQuery(accountId));
            if (queryResponse.IsNotFound)
            {
                return NotFound();
            }

            if (queryResponse.ValidationErrorMessages.Any())
            {
                return BadRequest(queryResponse.ValidationErrorMessages);
            }

            var accountResponse = Mapper.Map<AccountResponse>(queryResponse.AccountDto);
            return Ok(accountResponse);
        }
    }

    public class GetAccountDetailsQuery : IRequest<GetAccountDetailsQueryResponse>
    {
        public Guid AccountId { get; }

        public GetAccountDetailsQuery(Guid accountId)
        {
            AccountId = accountId;
        }
    }

    public class AccountResponse
    {
        public Guid Account { get; set; }
        public string AccountName { get; set; }
    }

    public class GetAccountDetailsQueryResponse
    {
        public IEnumerable<string> ValidationErrorMessages { get; set; }
        public bool IsNotFound { get; set; }
        public AccountDto AccountDto { get; set; }
    }

    public class AccountDto
    {
        public Guid Account { get; set; }
        public string AccountName { get; set; }
    }
}
