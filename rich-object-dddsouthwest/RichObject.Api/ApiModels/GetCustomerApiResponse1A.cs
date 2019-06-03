using System;
using System.Collections.Generic;

namespace RichObject.Api.ApiModels
{
    public class GetCustomerResponse1A
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public IEnumerable<AddressResponse1A> PastAddresses { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNumber { get; set; }
        public AddressResponse1A CurrentAddress { get; set; }
    }
}