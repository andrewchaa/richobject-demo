using System;
using MediatR;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Models;

namespace RichObject.Domain.Commands
{
    public class ChangeCustomerAddressCommand4 : IRequest<OperationResult<Unit>>
    {
        public Guid CustomerId { get; }
        public Address4 Address { get; }

        public ChangeCustomerAddressCommand4(Guid customerId, Address4 address)
        {
            CustomerId = customerId;
            Address = address;
        }
    }
}