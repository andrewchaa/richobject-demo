using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RichObject.Domain.Models;

namespace RichObject.Domain.Repositories
{
    public interface IAddressRepository4A
    {
        Task<IEnumerable<Address4A>> List(Guid customerId);
        Task Insert(Address4A address);
        Task Update(Address4A address);
    }
}