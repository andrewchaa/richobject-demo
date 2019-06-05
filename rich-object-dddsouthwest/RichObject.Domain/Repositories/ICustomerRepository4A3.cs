using System;
using System.Threading.Tasks;
using RichObject.Domain.Models;

namespace RichObject.Domain.Repositories
{
    public interface ICustomerRepository4A3
    {
        Task<Customer4A> Get(Guid customerId);
        Task<Customer4A> Get(Guid customerId, IAddressRepository4A3 addressRepository);
        Task<Guid> Save(Customer4A customer);
        Task<bool> Exist(Guid customerCustomerId);
    }
}