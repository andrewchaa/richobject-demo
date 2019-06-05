using System;
using MediatR;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Models;

namespace RichObject.Domain.Commands
{
    public class ChangeCurrentAddressCommand4A : IRequest<OperationResult<Unit>>
    {
        public Guid CustomerId { get; }
        public Address4A Address { get; }

        public ChangeCurrentAddressCommand4A(Guid customerId,
            Address4A address)
        {
            CustomerId = customerId;
            Address = address;
        }
    }
}