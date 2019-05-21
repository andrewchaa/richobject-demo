using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RichObject.Domain.Models;

namespace RichObject.Domain.Repositories
{
    public interface IAddressRepository5A
    {
        Task<IEnumerable<Address5A>> List(Guid customerId);
        Task Insert(Address5A address);
        Task Update(Address5A address);
    }
}