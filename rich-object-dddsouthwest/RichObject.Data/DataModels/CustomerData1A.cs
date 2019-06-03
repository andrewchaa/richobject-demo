using System;
using System.Collections.Generic;

namespace RichObject.Data.DataModels
{
    public class CustomerData1A
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNumber { get; set; }
        public IEnumerable<AddressData1A> Addresses { get; set; }
    }
}