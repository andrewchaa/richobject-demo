using System;
using System.Threading.Tasks;
using RichObject.Domain.Models;

namespace RichObject.Domain.Repositories
{
    public interface ICustomerRepository4A1
    {
        Task<Customer4A1> Get(Guid customerId);
        Task<Customer4A1> Get(Guid customerId, IAddressRepository4A addressRepository);
        Task<Guid> Save(Customer4A1 customer);
        Task<bool> Exist(Guid customerCustomerId);
        Task<Guid> SaveAddresses(Customer4A1 customer);
    }
}