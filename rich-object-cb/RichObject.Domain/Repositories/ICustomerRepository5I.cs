using System;
using System.Threading.Tasks;
using RichObject.Domain.Commands;
using RichObject.Domain.Models;

namespace RichObject.Domain.Repositories
{
    public interface ICustomerRepository5I
    {
        Task<Customer5I> Get(Guid customerId);
        Task<Guid> Save(Customer5I customer);
        Task<bool> Exist(Guid customerCustomerId);
    }
}