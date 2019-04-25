using System;
using MediatR;
using RichObject.Domain.Models;

namespace RichObject.Domain.Commands
{
    public class ChangeCustomerCurrentAddressCommand5I : IRequest<OperationResult<Unit>>
    {
        public Guid CustomerId { get; }
        public Address5I Address { get; }

        public ChangeCustomerCurrentAddressCommand5I(Guid customerId,
            Address5I address)
        {
            CustomerId = customerId;
            Address = address;
        }
    }
}