using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RichObject.Domain.Repositories
{
    public interface ICustomerRepositoryV3
    {
        Task<CustomerDataV2> Get(Guid customerId);
    }
    
    public class CustomerDataV2
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNumber { get; set; }
        public IEnumerable<AddressDataV2> Addresses { get; set; }
    }
    
    public class AddressDataV2
    {
        public bool CurrentAddress { get; set; }
        public string HouseNoOrName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
    }

}