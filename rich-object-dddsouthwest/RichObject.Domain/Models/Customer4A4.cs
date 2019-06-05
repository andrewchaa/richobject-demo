using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RichObject.Domain.Commands;
using RichObject.Domain.Repositories;
using RichObject.Domain.Values;

namespace RichObject.Domain.Models
{
    public class Customer4A4
    {
        public Guid CustomerId { get; }
        public CustomerName Name { get; }
        public IEnumerable<Address4A> Addresses { get; }
        public Dob DateOfBirth { get; }
        public IdDocument IdDocument { get; }
        
        public IList<IRequest> Commands { get; }
        
        public Customer4A4(Guid customerId,
            CustomerName name, 
            Dob dateOfBirth, 
            IdDocument idDocument, 
            IEnumerable<Address4A> addresses)

        {
            CustomerId = customerId;
            Name = name;
            DateOfBirth = dateOfBirth;
            IdDocument = idDocument;
            Addresses = addresses;
            
            Commands = new List<IRequest>();
        }

        public void ChangeCurrentAddress(Address4A newCurrentAddress)
        {
            var existingCurrentAddress = Addresses.Single(a => a.CurrentAddress);
            existingCurrentAddress.SetCurrentAddress(false);

            Commands.Add(new UpdateAddressCommand(existingCurrentAddress,
                newCurrentAddress));
        }
    }
}