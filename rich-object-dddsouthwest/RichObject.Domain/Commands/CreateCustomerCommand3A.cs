using System;
using MediatR;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Models;

namespace RichObject.Domain.Commands
{
    public class CreateCustomerCommand3A : IRequest<OperationResult<Guid>>
    {
        public Customer3A Customer { get; }

        public CreateCustomerCommand3A(Customer3A customer)
        {
            Customer = customer;
        }
    }
}