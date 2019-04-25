using System;
using System.Collections.Generic;

namespace RichObject.Domain.Models
{
    public class Customer1Ans
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Title { get; }
        public IEnumerable<AddressAns1> Addresses { get; }
        public DateTime DateOfBirth { get; }
        public string IdDocumentType { get; }
        public string IdDocumentNumber { get; }

        public Customer1Ans(string firstName, 
            string lastName, 
            string title, 
            DateTime dateOfBirth, 
            string idDocumentType, 
            string idDocumentNumber, 
            IEnumerable<AddressAns1> addresses)
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