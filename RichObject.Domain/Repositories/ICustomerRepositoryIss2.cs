using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RichObject.Domain.Repositories
{
    public interface ICustomerRepositoryIss2
    {
        Task<CustomerDataIss2> Get(Guid customerId);
    }

    public class CustomerDataIss2
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNumber { get; set; }
        public IEnumerable<AddressDataIss2> Addresses { get; set; }
    }
    
    public class AddressDataIss2
    {
        public bool CurrentAddress { get; set; }
        public string HouseNoOrName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
    }
}