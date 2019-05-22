using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RichObject.Domain.Repositories;

namespace RichObject.Domain.Models
{
    public class Customer5A
    {
        public Guid CustomerId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Title { get; }
        public IEnumerable<Address2> Addresses { get; }
        public DateTime DateOfBirth { get; }
        public string IdDocumentType { get; }
        public string IdDocumentNumber { get; }

        private readonly IAddressRepository5A _addressRepository;

        public Customer5A(Guid customerId,
            string firstName, 
            string lastName, 
            string title, 
            DateTime dateOfBirth, 
            string idDocumentType, 
            string idDocumentNumber, 
            IEnumerable<Address2> addresses)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Title = title;
            DateOfBirth = dateOfBirth;
            IdDocumentType = idDocumentType;
            IdDocumentNumber = idDocumentNumber;
            Addresses = addresses;
        }

        public Customer5A(Guid customerId,
            string firstName, 
            string lastName, 
            string title, 
            DateTime dateOfBirth, 
            string idDocumentType, 
            string idDocumentNumber, 
            IEnumerable<Address2> addresses, 
            IAddressRepository5A addressRepository) : this(customerId,
            firstName,
            lastName,
            title,
            dateOfBirth,
            idDocumentType,
            idDocumentNumber,
            addresses)
        
        {
            _addressRepository = addressRepository;
        }

        public async Task ChangeCurrentAddress(Address5A address)
        {
            var addresses = await _addressRepository.List(CustomerId);
            var existingCurrentAddress = addresses.Single(a => a.CurrentAddress);
            existingCurrentAddress.SetCurrentAddress(false);

            await _addressRepository.Update(existingCurrentAddress);
            await _addressRepository.Insert(address);
        }
    }
}