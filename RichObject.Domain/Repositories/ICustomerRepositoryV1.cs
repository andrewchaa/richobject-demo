using System;
using System.Threading.Tasks;
using RichObject.Domain.Models;

namespace RichObject.Domain.Repositories
{
    public interface ICustomerRepositoryV1
    {
        Task<CustomerV1> Get(Guid customerId);
    }
}