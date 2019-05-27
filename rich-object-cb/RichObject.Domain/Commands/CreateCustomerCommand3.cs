using System;
using MediatR;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Models;

namespace RichObject.Domain.Commands
{
    public class CreateCustomerCommand3 : IRequest<OperationResult<Guid>>
    {
        public Customer3 Customer { get; }

        public CreateCustomerCommand3(Customer3 customer)
        {
            Customer = customer;
        }
    }
}