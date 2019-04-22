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
    public class AccountsV2Controller : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAccountValidator _validator;

        public AccountsV2Controller(IMediator mediator, 
            IAccountValidator validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        [HttpGet("{accountId}")]
        public async Task<ActionResult<AccountResponse>> Get(Guid accountId)
        {
            var validationResult = _validator.Validate(accountId);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ErrorMessages);
            }
            
            var optionalAccount = await _mediator.Send(new GetAccountDetailsQuery(accountId));
//            if (!optionalAccount.HasValue)
//            {
//                return NotFound();
//            }
            
//            return Ok(new AccountResponse(optionalAccount));
            return Ok();
        }
    }

    public interface IAccountValidator
    {
        AccountValidationResult Validate(Guid accountId);
    }

    public class AccountValidationResult
    {
        public bool IsValid { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; }
    }

}
