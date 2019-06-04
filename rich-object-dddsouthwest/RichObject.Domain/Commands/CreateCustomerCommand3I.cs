using System;
using MediatR;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Models;

namespace RichObject.Domain.Commands
{
    public class CreateCustomerCommand3I : IRequest<OperationResult<Guid>>
    {
        public Customer3I Customer { get; }

        public CreateCustomerCommand3I(Customer3I customer)
        {
            Customer = customer;
        }
    }
}