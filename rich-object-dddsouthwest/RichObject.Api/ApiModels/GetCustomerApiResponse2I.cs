using System;
using System.Collections.Generic;

namespace RichObject.Api.ApiModels
{
    public class GetCustomerApiResponse2I
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public IEnumerable<AddressResponse2A> PastAddresses { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNumber { get; set; }
        public AddressResponse2A CurrentAddress { get; set; }
    }
}