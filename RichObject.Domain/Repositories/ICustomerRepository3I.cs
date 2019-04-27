using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RichObject.Domain.Repositories
{
    public interface ICustomerRepository3I
    {
        Task<CustomerData3I> Get(Guid customerId);
        Task<CustomerData3I> Insert(CustomerData3I customerData);
    }
    
    public class CustomerData3I
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