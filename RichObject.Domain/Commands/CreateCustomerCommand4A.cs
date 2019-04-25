using System;
using MediatR;
using RichObject.Domain.Models;

namespace RichObject.Domain.Commands
{
    public class CreateCustomerCommand4A : IRequest<OperationResponse<Guid>>
    {
        public Customer4A Customer { get; }

        public CreateCustomerCommand4A(Customer4A customer)
        {
            Customer = customer;
        }
    }
}