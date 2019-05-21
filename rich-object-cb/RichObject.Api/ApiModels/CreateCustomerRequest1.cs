using System;
using System.Collections.Generic;

namespace RichObject.Api.ApiModels
{
    public class CreateCustomerRequest1
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Title { get; set; }
        public IEnumerable<AddressRequestAns3> Addresses { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CountryOfBirth { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNumber { get; set; }
        public string VatNumber { get; set; }
        public string VatCountry { get; set; }
    }
}