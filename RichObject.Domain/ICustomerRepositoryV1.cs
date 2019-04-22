using System;
using System.Threading.Tasks;

namespace RichObject.Domain
{
    public interface ICustomerRepositoryV1
    {
        Task<CustomerV1> Get(Guid customerId);
    }
}