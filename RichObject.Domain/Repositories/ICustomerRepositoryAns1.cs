using System;
using System.Threading.Tasks;
using RichObject.Domain.Models;

namespace RichObject.Domain.Repositories
{
    public interface ICustomerRepositoryAns1
    {
        Task<CustomerAns1> Get(Guid customerId);
    }
}