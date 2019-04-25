using System;
using System.Collections.Generic;

namespace RichObject.Api.ApiModels
{
    public class CustomerRequest4Iss
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public IEnumerable<AddressRequest4Iss> Addresses { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNumber { get; set; }
    }
}