using System;
using MediatR;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Models;

namespace RichObject.Domain.Commands
{
    public class CreateCustomerCommand4I : IRequest<OperationResult<Guid>>
    {
        public Customer4I Customer { get; }

        public CreateCustomerCommand4I(Customer4I customer)
        {
            Customer = customer;
        }
    }
}