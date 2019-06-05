using System;
using System.Threading.Tasks;
using RichObject.Domain.Models;

namespace RichObject.Domain.Repositories
{
    public interface ICustomerAddressRepository4A2
    {
        Task<CustomerAddress4A2> Get(Guid customerId);
        Task<Guid> Save(CustomerAddress4A2 customerAddress);
    }
}