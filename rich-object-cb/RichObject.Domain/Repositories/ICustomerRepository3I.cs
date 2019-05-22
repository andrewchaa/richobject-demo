using System;
using System.Threading.Tasks;
using RichObject.Domain.Models;

namespace RichObject.Domain.Repositories
{
    public interface ICustomerRepository3I
    {
        Task<CustomerData1> Get(Guid customerId);
        Task<CustomerData1> Insert(CustomerData1 customerData);
    }
}