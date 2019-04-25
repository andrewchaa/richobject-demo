using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using RichObject.Domain;
using RichObject.Domain.Models;
using RichObject.Domain.Repositories;

namespace RichObject.Data.Repositories
{
    public class CustomerRepositoryAns1 : ICustomerRepository1A
    {
        public async Task<Customer1Ans> Get(Guid customerId)
        {
            using (var conn = new SqlConnection())
            {
                var customerData = await conn.QuerySingleOrDefaultAsync<CustomerDataAns1>(
                    "SELECT * FROM Customers WHERE CustomerId = @customerId",
                    new {customerId});
                var addressesData = await conn.QueryAsync<AddressDataAns1>(
                    "SELECT * FROM Addresses WHERE Customer",
                    new {customerId});

                var addresses = addressesData.Select(a => new AddressAns1(a.HouseNoOrName,
                    a.Street,
                    a.City,
                    a.County,
                    a.PostCode,
                    a.CurrentAddress));
                
                return new Customer1Ans(customerData.FirstName,
                    customerData.LastName,
                    customerData.Title,
                    customerData.DateOfBirth,
                    customerData.IdDocumentType,
                    customerData.IdDocumentNumber,
                    addresses);
            }
        }
    }
    
    public class CustomerDataAns1
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNumber { get; set; }
    }
    
    public class AddressDataAns1
    {
        public bool CurrentAddress { get; set; }
        public string HouseNoOrName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
    }


}