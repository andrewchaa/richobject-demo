using System;
using System.Collections.Generic;
using RichObject.Api.Controllers;

namespace RichObject.Api.ApiModels
{
    public class CustomerRequest2I
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public IEnumerable<AddressRequest1Ans> Addresses { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNumber { get; set; }
    }
}