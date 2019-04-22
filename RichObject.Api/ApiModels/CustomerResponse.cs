using System;
using System.Collections.Generic;
using RichObject.Domain;

namespace RichObject.Api.ApiModels
{
    public class CustomerResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public IEnumerable<AddressResponse> Addresses { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNumber { get; set; }

    }
}