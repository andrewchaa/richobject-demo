using System;
using System.Threading.Tasks;
using RichObject.Domain.Models;

namespace RichObject.Domain.Repositories
{
    public interface ICustomerRepository2
    {
        Task<CustomerData1> Get(Guid customerId);
        Task<CustomerData1> Insert(Customer2 customerData);
    }
}