using System;
using System.Threading.Tasks;
using RichObject.Domain.Models;

namespace RichObject.Domain.Repositories
{
    public interface ICustomerRepository3A
    {
        Task<Customer1A> Get(Guid customerId);
        Task<Guid> Save(Customer3A customer);
        Task<bool> Exist(Guid customerCustomerId);
    }
}