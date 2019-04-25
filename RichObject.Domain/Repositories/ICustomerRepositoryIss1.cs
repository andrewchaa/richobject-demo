using System;
using System.Threading.Tasks;
using RichObject.Domain.Models;

namespace RichObject.Domain.Repositories
{
    public interface ICustomerRepositoryIss1
    {
        Task<Customer1Iss> Get(Guid customerId);
    }
}