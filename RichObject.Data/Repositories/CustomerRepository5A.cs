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
    public class CustomerRepository5A : ICustomerRepository5A
    {
        public async Task<Customer5A> Get(Guid customerId)
        {
            using (var conn = new SqlConnection())
            {
                var customerData = await conn.QuerySingleOrDefaultAsync<CustomerData5A>(
                    "SELECT * FROM Customers WHERE CustomerId = @customerId",
                    new {customerId});
                var addressesData = await conn.QueryAsync<AddressData5A>(
                    "SELECT * FROM Addresses WHERE Customer",
                    new {customerId});

                var addresses = addressesData.Select(a => new Address1A(a.HouseNoOrName,
                    a.Street,
                    a.City,
                    a.County,
                    a.PostCode,
                    a.CurrentAddress));
                
                return new Customer5A(customerData.CustomerId,
                    customerData.FirstName,
                    customerData.LastName,
                    customerData.Title,
                    customerData.DateOfBirth,
                    customerData.IdDocumentType,
                    customerData.IdDocumentNumber,
                    addresses);
            }
        }

        public async Task<Customer5A> Get(Guid customerId, 
            IAddressRepository5A addressRepository)
        {
            using (var conn = new SqlConnection())
            {
                var customerData = await conn.QuerySingleOrDefaultAsync<CustomerData5A>(
                    "SELECT * FROM Customers WHERE CustomerId = @customerId",
                    new {customerId});
                var addressesData = await conn.QueryAsync<AddressData5A>(
                    "SELECT * FROM Addresses WHERE Customer",
                    new {customerId});

                var addresses = addressesData.Select(a => new Address1A(a.HouseNoOrName,
                    a.Street,
                    a.City,
                    a.County,
                    a.PostCode,
                    a.CurrentAddress));
                
                return new Customer5A(customerData.CustomerId,
                    customerData.FirstName,
                    customerData.LastName,
                    customerData.Title,
                    customerData.DateOfBirth,
                    customerData.IdDocumentType,
                    customerData.IdDocumentNumber,
                    addresses,
                    addressRepository);
            }
        }

        public async Task<Guid> Save(Customer5A customer)
        {
            return Guid.NewGuid();
        }

        public async Task<bool> Exist(Guid customerCustomerId)
        {
            return true;
        }
    }
    
    public class CustomerData5A
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNumber { get; set; }
    }
    
    public class AddressData5A
    {
        public bool CurrentAddress { get; set; }
        public string HouseNoOrName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
    }


}