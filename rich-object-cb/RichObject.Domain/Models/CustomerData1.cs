using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RichObject.Domain.Models
{
    public class CustomerData1
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNumber { get; set; }
        public IEnumerable<AddressData1> Addresses { get; set; }

        public async Task ChangeCustomerAddress(Address3 address)
        {
            
        }
    }
}