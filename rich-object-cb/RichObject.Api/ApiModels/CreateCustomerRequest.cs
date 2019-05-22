using System;
using System.Collections.Generic;
using RichObject.Domain.Models;

namespace RichObject.Api.ApiModels
{
    public class CreateCustomerRequest
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Title { get; set; }
        public AddressRequest Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public CountryCode CountryOfBirth { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNumber { get; set; }
        public string VatNumber { get; set; }
        public CountryCode VatCountry { get; set; }
    }
}