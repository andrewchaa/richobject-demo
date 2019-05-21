using System;
using System.Collections.Generic;

namespace RichObject.Api.ApiModels
{
    public class CustomerRequestAns3
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public IEnumerable<AddressRequestAns3> Addresses { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNumber { get; set; }
    }
}