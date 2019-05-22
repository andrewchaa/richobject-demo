using System;
using MediatR;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Models;

namespace RichObject.Domain.Commands
{
    public class CreateCustomerCommand4A : IRequest<OperationResult<Guid>>
    {
        public Customer4A Customer { get; }

        public CreateCustomerCommand4A(Customer4A customer)
        {
            Customer = customer;
        }
    }
}