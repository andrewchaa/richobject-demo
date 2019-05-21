using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RichObject.Domain.Models;

namespace RichObject.Domain.Repositories
{
    public interface IAddressRepository5I
    {
        Task<IEnumerable<Address5I>> List(Guid customerId);
        Task Insert(Address5I address);
        Task Update(Address5I address);
    }
}