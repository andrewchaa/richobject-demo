using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RichObject.Domain.Models;

namespace RichObject.Domain.Repositories
{
    public interface IAddressRepository4I
    {
        Task<IEnumerable<Address4I>> List(Guid customerId);
        Task Insert(Guid commandCustomerId, Address4I address);
        Task Update(Guid commandCustomerId, Address4I address);
    }
}