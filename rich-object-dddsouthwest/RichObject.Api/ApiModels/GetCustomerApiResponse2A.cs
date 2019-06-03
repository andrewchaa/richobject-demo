using System;
using System.Collections.Generic;
using System.Linq;
using RichObject.Domain.Models;

namespace RichObject.Api.ApiModels
{
    public class GetCustomerApiResponse2A
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Title { get; }
        public IEnumerable<AddressResponse2A> PastAddresses { get; }
        public DateTime DateOfBirth { get; }
        public string IdDocumentType { get; }
        public string IdDocumentNumber { get; }
        public AddressResponse2A CurrentAddress { get; }

        public GetCustomerApiResponse2A(Customer2A customer)
        {
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Title = customer.Title;
            PastAddresses = customer.Addresses
                .Where(a => !a.CurrentAddress)
                .Select(a => new AddressResponse2A(a));
            CurrentAddress = new AddressResponse2A(customer.Addresses
                .Single(a => a.CurrentAddress));
            DateOfBirth = customer.DateOfBirth;
            IdDocumentType = customer.IdDocumentType;
            IdDocumentNumber = customer.IdDocumentNumber;
        }
    }
}