using System;
using System.Collections.Generic;
using MediatR;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Models;

namespace RichObject.Domain.Commands
{
    public class CreateCustomerCommand2 : IRequest<OperationResult<Guid>>
    {
        public Customer2 Customer { get; }

        public CreateCustomerCommand2(Customer2 customer)
        {
            Customer = customer;
        }
    }
}