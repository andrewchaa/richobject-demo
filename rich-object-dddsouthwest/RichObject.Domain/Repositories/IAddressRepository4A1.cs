using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RichObject.Domain.Models;

namespace RichObject.Domain.Repositories
{
    public interface IAddressRepository4A1
    {
        Task<IEnumerable<Address4A>> List(Guid customerId);
        Task Save(Customer4A1 customer);
    }
}