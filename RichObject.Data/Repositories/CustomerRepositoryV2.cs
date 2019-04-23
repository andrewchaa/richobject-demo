using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using RichObject.Domain;

namespace RichObject.Data.Repositories
{
    public class CustomerRepositoryV2 : ICustomerRepositoryV2
    {
        public async Task<CustomerV2> Get(Guid customerId)
        {
            using (var conn = new SqlConnection())
            {
                var customerData = await conn.QuerySingleOrDefaultAsync<CustomerData>(
                    "SELECT * FROM Customers WHERE CustomerId = @customerId",
                    new {customerId});
                var addressesData = await conn.QueryAsync<AddressData>(
                    "SELECT * FROM Addresses WHERE Customer",
                    new {customerId});

                var addresses = addressesData.Select(a => new AddressV2(a.HouseNoOrName,
                    a.Street,
                    a.City,
                    a.County,
                    a.PostCode,
                    a.CurrentAddress));
                
                return new CustomerV2(customerData.FirstName,
                    customerData.LastName,
                    customerData.Title,
                    customerData.DateOfBirth,
                    customerData.IdDocumentType,
                    customerData.IdDocumentNumber,
                    addresses);
            }
        }
    }
    
    public class CustomerData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNumber { get; set; }
    }
    
    public class AddressData
    {
        public bool CurrentAddress { get; set; }
        public string HouseNoOrName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
    }


}