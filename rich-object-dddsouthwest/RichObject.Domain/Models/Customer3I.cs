using System;
using System.Collections.Generic;

namespace RichObject.Domain.Models
{
    public class Customer3I
    {
        public Guid CustomerId { get; }

        public string FirstName { get; }
        public string LastName { get; }
        public string Title { get; }
        public IEnumerable<Address3I> Addresses { get; }
        public DateTime DateOfBirth { get; }
        public string IdDocumentType { get; }
        public string IdDocumentNumber { get; }

        public Customer3I(Guid customerId, 
            string firstName, 
            string lastName, 
            string title, 
            DateTime dateOfBirth, 
            string idDocumentType, 
            string idDocumentNumber, 
            IEnumerable<Address3I> addresses)
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

        public Customer3I(string firstName, 
            string lastName, 
            string title, 
            DateTime dateOfBirth, 
            string idDocumentType, 
            string idDocumentNumber, 
            IEnumerable<Address3I> addresses) : this(Guid.Empty, 
            firstName, 
            lastName,
            title,
            dateOfBirth,
            idDocumentType,
            idDocumentNumber,
            addresses)
        {}

    }
}