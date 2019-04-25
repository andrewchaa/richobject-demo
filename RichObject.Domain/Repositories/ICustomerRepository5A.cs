using System;
using System.Threading.Tasks;
using RichObject.Domain.Models;

namespace RichObject.Domain.Repositories
{
    public interface ICustomerRepository5A
    {
        Task<Customer5A> Get(Guid customerId);
        Task<Customer5A> Get(Guid customerId, IAddressRepository5A addressRepository);
        Task<Guid> Save(Customer5A customer);
        Task<bool> Exist(Guid customerCustomerId);
    }
}