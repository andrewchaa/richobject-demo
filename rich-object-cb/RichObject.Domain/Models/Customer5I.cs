using System;
using System.Collections.Generic;

namespace RichObject.Domain.Models
{
    public class Customer5I
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Title { get; }
        public IEnumerable<Address1A> Addresses { get; }
        public DateTime DateOfBirth { get; }
        public string IdDocumentType { get; }
        public string IdDocumentNumber { get; }

        public Customer5I(string firstName, 
            string lastName, 
            string title, 
            DateTime dateOfBirth, 
            string idDocumentType, 
            string idDocumentNumber, 
            IEnumerable<Address1A> addresses)
        {
            FirstName = firstName;
            LastName = lastName;
            Title = title;
            DateOfBirth = dateOfBirth;
            IdDocumentType = idDocumentType;
            IdDocumentNumber = idDocumentNumber;
            Addresses = addresses;
        }

    }
}