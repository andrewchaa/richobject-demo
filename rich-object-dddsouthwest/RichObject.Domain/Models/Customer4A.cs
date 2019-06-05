using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RichObject.Domain.Repositories;
using RichObject.Domain.Values;

namespace RichObject.Domain.Models
{
    public class Customer4A
    {
        public Guid CustomerId { get; }
        public CustomerName Name { get; }
        public IEnumerable<Address4A> Addresses { get; }
        public Dob DateOfBirth { get; }
        public IdDocument IdDocument { get; }

        private readonly IAddressRepository4A3 _addressRepository;

        public Customer4A(Guid customerId,
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
        }

        public Customer4A(Guid customerId,
            CustomerName name, 
            Dob dateOfBirth, 
            IdDocument idDocument, 
            IEnumerable<Address4A> addresses, 
            IAddressRepository4A3 addressRepository) : this(customerId,
            name,
            dateOfBirth,
            idDocument,
            addresses)
        
        {
            _addressRepository = addressRepository;
        }

        public async Task ChangeCurrentAddress(Address4A address)
        {
            var addresses = await _addressRepository.List(CustomerId);
            var existingCurrentAddress = addresses.Single(a => a.CurrentAddress);
            existingCurrentAddress.SetCurrentAddress(false);

            await _addressRepository.Update(existingCurrentAddress);
            await _addressRepository.Insert(address);
        }
    }
}