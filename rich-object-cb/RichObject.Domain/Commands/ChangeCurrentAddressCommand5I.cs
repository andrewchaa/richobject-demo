using System;
using MediatR;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Models;

namespace RichObject.Domain.Commands
{
    public class ChangeCurrentAddressCommand5I : IRequest<OperationResult<Unit>>
    {
        public Guid CustomerId { get; }
        public Address5I Address { get; }

        public ChangeCurrentAddressCommand5I(Guid customerId,
            Address5I address)
        {
            CustomerId = customerId;
            Address = address;
        }
    }
}