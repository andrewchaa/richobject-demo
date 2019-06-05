using System;
using MediatR;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Models;

namespace RichObject.Domain.Commands
{
    public class ChangeCurrentAddressCommand4I : IRequest<OperationResult<Unit>>
    {
        public Guid CustomerId { get; }
        public Address4I Address { get; }

        public ChangeCurrentAddressCommand4I(Guid customerId,
            Address4I address)
        {
            CustomerId = customerId;
            Address = address;
        }
    }
}