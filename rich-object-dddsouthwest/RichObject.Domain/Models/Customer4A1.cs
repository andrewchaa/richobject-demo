using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RichObject.Domain.Repositories;

namespace RichObject.Domain.Models
{
    public class Customer4A1
    {
        public Guid CustomerId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Title { get; }
        public IList<Address4A> Addresses { get; }
        public DateTime DateOfBirth { get; }
        public string IdDocumentType { get; }
        public string IdDocumentNumber { get; }
        

        public Customer4A1(Guid customerId,
            string firstName, 
            string lastName, 
            string title, 
            DateTime dateOfBirth, 
            string idDocumentType, 
            string idDocumentNumber, 
            IList<Address4A> addresses)
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

        public void ChangeCurrentAddress(Address4A address)
        {
            var existingCurrentAddress = Addresses.Single(a => a.CurrentAddress);
            existingCurrentAddress.SetCurrentAddress(false);
            
            Addresses.Add(address);
        }
    }
}