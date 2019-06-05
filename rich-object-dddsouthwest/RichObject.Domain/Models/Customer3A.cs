using System;
using System.Collections.Generic;
using RichObject.Domain.Values;

namespace RichObject.Domain.Models
{
    public class Customer3A
    {
        public Guid CustomerId { get; }
        public CustomerName Name { get; }
        public IEnumerable<Address3A> Addresses { get; }
        public Dob DateOfBirth { get; }
        public IdDocument IdDocument { get; }

        public Customer3A(Guid customerId,
            CustomerName name, 
            Dob dateOfBirth, 
            IdDocument idDocument, 
            IEnumerable<Address3A> addresses)
        {
            CustomerId = customerId;
            Name = name;
            DateOfBirth = dateOfBirth;
            IdDocument = idDocument;
            Addresses = addresses;
        }

    }
}