using System;
using System.Collections.Generic;
using MediatR;
using RichObject.Domain.CommandHandlers;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Models;

namespace RichObject.Domain.Commands
{
    public class CreateCustomerCommand2A : IRequest<OperationResult<Customer2A>>
    {
        public Customer2A Customer { get; }

        public CreateCustomerCommand2A(Customer2A customer)
        {
            Customer = customer;
        }
    }
}