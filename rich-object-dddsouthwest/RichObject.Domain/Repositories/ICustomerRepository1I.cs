using System;
using System.Threading.Tasks;
using RichObject.Domain.Models;

namespace RichObject.Domain.Repositories
{
    public interface ICustomerRepository1I
    {
        Task<Customer1I> Get(Guid customerId);
    }
}