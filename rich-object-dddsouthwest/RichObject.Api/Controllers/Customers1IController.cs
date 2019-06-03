using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RichObject.Domain;
using RichObject.Domain.Models;
using RichObject.Domain.Queries;
using RichObject.Domain.Repositories;

namespace RichObject.Api.Controllers
{
    /// <summary>
    /// A single model coupled to Database and to API interface 
    /// </summary>

    [ApiController]
    [Route("api/[controller]")]
    public class Customers1IController : Controller
    {
        private readonly IMediator _mediator;
        

        public Customers1IController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer1I>> Get(Guid id)
        {
            var customer = await _mediator.Send(new GetCustomerQuery1I(id));
            
            return Ok(customer);
        }
    }

}