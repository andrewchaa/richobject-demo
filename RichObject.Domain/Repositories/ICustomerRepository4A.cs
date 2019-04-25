using System;
using System.Threading.Tasks;
using RichObject.Domain.Models;

namespace RichObject.Domain.Repositories
{
    public interface ICustomerRepository4A
    {
        Task<Customer1Ans> Get(Guid customerId);
        Task<Guid> Save(Customer4A customer);
        Task<bool> Exist(Guid customerCustomerId);
    }
}