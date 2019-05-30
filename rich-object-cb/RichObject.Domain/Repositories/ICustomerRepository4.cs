using System;
using System.Threading.Tasks;
using RichObject.Domain.Models;

namespace RichObject.Domain.Repositories
{
    public interface ICustomerRepository4
    {
        Task<Customer4> Get(Guid customerId);
        Task<Customer4> Get(Guid customerId, IAddressRepository4 addressRepository);
        Task<Guid> Insert(Customer4 customerData);
    }
}