using System;
using System.Threading.Tasks;
using MediatR;
using RichObject.Domain.Models;

namespace RichObject.Domain.Repositories
{
    public interface ICustomerRepository4A4
    {
        Task<Customer4A4> Get(Guid customerId);
        Task<Guid> Save(Customer4A4 customer);
    }
}