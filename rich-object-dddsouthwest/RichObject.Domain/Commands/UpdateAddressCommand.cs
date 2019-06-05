using MediatR;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Models;

namespace RichObject.Domain.Commands
{
    public class UpdateAddressCommand : IRequest
    {
        public Address4A OldCurrentAddress { get; }
        public Address4A NewCurrentAddress { get; }

        public UpdateAddressCommand(Address4A oldCurrentAddress, Address4A newCurrentAddress)
        {
            OldCurrentAddress = oldCurrentAddress;
            NewCurrentAddress = newCurrentAddress;
        }
    }
}