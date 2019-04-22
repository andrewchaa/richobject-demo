using System;
using System.Threading.Tasks;

namespace RichObject.Domain
{
    public interface ICustomerRepositoryV2
    {
        Task<CustomerV2> Get(Guid customerId);
    }
}