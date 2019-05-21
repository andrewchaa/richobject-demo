using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using RichObject.Domain;
using RichObject.Domain.Models;
using RichObject.Domain.Repositories;

namespace RichObject.Data.Repositories
{
    public class CustomerRepository1I : ICustomerRepository1I
    {
        private readonly string _connString;

        public CustomerRepository1I(string connString)
        {
            _connString = connString;
        }
        
        public async Task<Customer1I> Get(Guid customerId)
        {
            using (var conn = new SqlConnection(_connString))
            {
                var customer = await conn.QuerySingleOrDefaultAsync<Customer1I>(
                    "SELECT * FROM Customers WHERE CustomerId = @customerId",
                    new {customerId});
                customer.Addresses = await conn.QueryAsync<Address1I>(
                    "SELECT * FROM Addresses WHERE Customer",
                    new {customerId});

                return customer;
            }
        }
    }
}