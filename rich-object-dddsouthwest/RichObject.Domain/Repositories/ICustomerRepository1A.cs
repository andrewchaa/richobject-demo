using System;
using System.Threading.Tasks;
using RichObject.Domain.Models;

namespace RichObject.Domain.Repositories
{
    public interface ICustomerRepository1A
    {
        Task<Customer1A> Get(Guid customerId);
    }
}