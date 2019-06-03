using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RichObject.Api.ApiModels;
using RichObject.Domain;
using RichObject.Domain.Queries;
using RichObject.Domain.Repositories;

namespace RichObject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Customers1AController : Controller
    {
        private readonly IMediator _mediator;

        public Customers1AController(IMediator mediator, ICustomerRepository1A customerRepository)
        {
            _mediator = mediator;
        }
        
        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCustomerResponse1A>> Get(Guid id)
        {
            var customer = await _mediator.Send(new GetCustomerQuery1A(id));

            var currentAddress = customer.Addresses.Single(a => a.CurrentAddress);
            var customerResponse = new GetCustomerResponse1A
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Title = customer.Title,
                CurrentAddress = new AddressResponse 
                {
                    HouseNoOrName = currentAddress.HouseNoOrName,
                    Street = currentAddress.Street,
                    City = currentAddress.City,
                    County = currentAddress.County,
                    PostCode = currentAddress.PostCode
                }, 
                PastAddresses =  customer.Addresses.Where(a => !a.CurrentAddress)
                    .Select(a => new AddressResponse
                {
                    HouseNoOrName = a.HouseNoOrName,
                    Street = a.Street,
                    City = a.City,
                    County = a.County,
                    PostCode = a.PostCode
                }),
                DateOfBirth = customer.DateOfBirth,
                IdDocumentType = customer.IdDocumentType,
                IdDocumentNumber = customer.IdDocumentNumber
            };
            
            return Ok(customerResponse);
        }
    }
}