using System;
using System.Collections.Generic;
using MediatR;
using RichObject.Domain.CommandHandlers;
using RichObject.Domain.Models;

namespace RichObject.Domain.Commands
{
    public class CreateCustomerCommand3A : IRequest<OperationResponse<Guid>>
    {
        public Customer3A Customer { get; }

        public CreateCustomerCommand3A(Customer3A customer)
        {
            Customer = customer;
        }
    }
}