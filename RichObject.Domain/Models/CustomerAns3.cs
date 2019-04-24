using System;
using System.Collections.Generic;

namespace RichObject.Domain.Models
{
    public class CustomerAns3
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Title { get; }
        public IEnumerable<AddressAns3> Addresses { get; }
        public DateTime DateOfBirth { get; }
        public string IdDocumentType { get; }
        public string IdDocumentNumber { get; }

        public CustomerAns3(string firstName, 
            string lastName, 
            string title, 
            DateTime dateOfBirth, 
            string idDocumentType, 
            string idDocumentNumber, 
            IEnumerable<AddressAns3> addresses)
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