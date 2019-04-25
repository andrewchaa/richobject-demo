using System;
using MediatR;
using RichObject.Domain.Models;

namespace RichObject.Domain.Commands
{
    public class CreateCustomerCommand4I : IRequest<OperationResponse<Guid>>
    {
        public Customer4I Customer { get; }

        public CreateCustomerCommand4I(Customer4I customer)
        {
            Customer = customer;
        }
    }
}