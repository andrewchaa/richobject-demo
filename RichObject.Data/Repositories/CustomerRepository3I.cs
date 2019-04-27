using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using RichObject.Domain;
using RichObject.Domain.Repositories;

namespace RichObject.Data.Repositories
{
    public class CustomerRepository3I : ICustomerRepository3I
    {
        public Task<CustomerData3I> Insert(CustomerData3I customerData)
        {
            throw new NotImplementedException();
        }

        Task<CustomerData3I> ICustomerRepository3I.Get(Guid customerId)
        {
            throw new NotImplementedException();
        }
    }
}