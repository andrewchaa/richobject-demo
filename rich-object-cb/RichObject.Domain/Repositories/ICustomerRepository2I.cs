using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RichObject.Domain.Repositories
{
    public interface ICustomerRepository2I
    {
        Task<CustomerData2I> Get(Guid customerId);
    }

    public class CustomerData2I
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNumber { get; set; }
        public IEnumerable<AddressData2I> Addresses { get; set; }
    }
    
    public class AddressData2I
    {
        public bool CurrentAddress { get; set; }
        public string HouseNoOrName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
    }
}