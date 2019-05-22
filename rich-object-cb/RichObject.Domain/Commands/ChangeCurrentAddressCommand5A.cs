using System;
using MediatR;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Models;

namespace RichObject.Domain.Commands
{
    public class ChangeCurrentAddressCommand5A : IRequest<OperationResult<Unit>>
    {
        public Guid CustomerId { get; }
        public Address5A Address { get; }

        public ChangeCurrentAddressCommand5A(Guid customerId,
            Address5A address)
        {
            CustomerId = customerId;
            Address = address;
        }
    }
}