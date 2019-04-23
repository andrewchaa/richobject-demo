using System;
using System.Threading.Tasks;
using RichObject.Domain.Models;

namespace RichObject.Domain.Repositories
{
    public interface ICustomerRepositoryV2
    {
        Task<CustomerV2> Get(Guid customerId);
    }
}