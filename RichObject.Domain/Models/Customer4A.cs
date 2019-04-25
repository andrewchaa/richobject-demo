using System.Collections.Generic;
using RichObject.Domain.Values;

namespace RichObject.Domain.Models
{
    public class Customer4A
    {
        public CustomerName Name { get; }
        public IEnumerable<AddressAns3> Addresses { get; }
        public Dob DateOfBirth { get; }
        public IdDocument IdDocument { get; }

        public Customer4A(CustomerName name, 
            Dob dateOfBirth, 
            IdDocument idDocument, 
            IEnumerable<AddressAns3> addresses)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            IdDocument = idDocument;
            Addresses = addresses;
        }

    }
}