using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RichObject.Domain.Repositories
{
    public interface ICustomerRepositoryIss3
    {
        Task<CustomerDataIss3> Get(Guid customerId);
    }
    
    public class CustomerDataIss3
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNumber { get; set; }
        public IEnumerable<AddressDataIss3> Addresses { get; set; }
    }
    
    public class AddressDataIss3
    {
        public bool CurrentAddress { get; set; }
        public string HouseNoOrName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
    }

}