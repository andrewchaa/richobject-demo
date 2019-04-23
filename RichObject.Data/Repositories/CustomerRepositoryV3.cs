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
    public class CustomerRepositoryV3 : ICustomerRepositoryV3
    {
        public async Task<CustomerDataV2> Get(Guid customerId)
        {
            using (var conn = new SqlConnection())
            {
                var customerData = await conn.QuerySingleOrDefaultAsync<CustomerDataV2>(
                    "SELECT * FROM Customers WHERE CustomerId = @customerId",
                    new {customerId});
                customerData.Addresses = await conn.QueryAsync<AddressDataV2>(
                    "SELECT * FROM Addresses WHERE Customer",
                    new {customerId});

                return customerData;
            }
        }
    }
}