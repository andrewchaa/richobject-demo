using System;
using System.Collections.Generic;
using RichObject.Domain.Values;

namespace RichObject.Domain.Models
{
    public class Customer4A
    {
        public Guid CustomerId { get; }
        public CustomerName Name { get; }
        public IEnumerable<Address2A> Addresses { get; }
        public Dob DateOfBirth { get; }
        public IdDocument IdDocument { get; }

        public Customer4A(Guid CustomerId,
            CustomerName name, 
            Dob dateOfBirth, 
            IdDocument idDocument, 
            IEnumerable<Address2A> addresses)
        {
            this.CustomerId = CustomerId;
            Name = name;
            DateOfBirth = dateOfBirth;
            IdDocument = idDocument;
            Addresses = addresses;
        }

    }
}