using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace RichObject.Domain
{
    public class CustomerV1
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public IEnumerable<AddressV1> Addresses { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNumber { get; set; }
    }
}