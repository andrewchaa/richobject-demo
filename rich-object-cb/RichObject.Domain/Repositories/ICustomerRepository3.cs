using System;
using System.Threading.Tasks;
using RichObject.Domain.Models;

namespace RichObject.Domain.Repositories
{
    public interface ICustomerRepository3
    {
        Task<CustomerData1> Get(Guid customerId);
        Task<CustomerData1> Insert(Customer3 customerData);
    }
}