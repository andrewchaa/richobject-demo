using System;
using System.Collections.Generic;

namespace RichObject.Domain
{
    public class CustomerV2
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Title { get; }
        public IEnumerable<AddressV2> Addresses { get; }
        public DateTime DateOfBirth { get; }
        public string IdDocumentType { get; }
        public string IdDocumentNumber { get; }

        public CustomerV2(string firstName, 
            string lastName, 
            string title, 
            DateTime dateOfBirth, 
            string idDocumentType, 
            string idDocumentNumber, 
            IEnumerable<AddressV2> addresses)
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