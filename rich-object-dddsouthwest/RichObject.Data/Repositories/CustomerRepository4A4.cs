

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using RichObject.Data.DataModels;
using RichObject.Domain;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Models;
using RichObject.Domain.Repositories;
using RichObject.Domain.Values;

namespace RichObject.Data.Repositories
{
    public class CustomerRepository4A4 : ICustomerRepository4A4
    {
        private readonly IMediator _mediator;

        public CustomerRepository4A4(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Guid> Save(Customer4A4 customer)
        {
            // Save Customer
            // ...
            // ...
            foreach (var command in customer.Commands)
            {
                await _mediator.Send(command);
            }

            return Guid.NewGuid();
        }

        public async Task<Customer4A4> Get(Guid customerId)
        {
            using (var conn = new SqlConnection())
            {
                var customerData = await conn.QuerySingleOrDefaultAsync<CustomerData4A>(
                    "SELECT * FROM Customers WHERE CustomerId = @customerId",
                    new {customerId});
                var addressesData = await conn.QueryAsync<AddressData4A>(
                    "SELECT * FROM Addresses WHERE Customer",
                    new {customerId});

                var nameResult = CustomerName.Create(customerData.Title,
                    customerData.FirstName,
                    customerData.LastName);
                var dobResult = Dob.Create(customerData.DateOfBirth);
                var idDocumentResult = IdDocument.Create(customerData.IdDocumentType,
                    customerData.IdDocumentNumber);
                
                var addresses = addressesData.Select(a => Address4A.Create(a.AddressId,
                    a.HouseNoOrName,
                    a.Street,
                    a.City,
                    a.County,
                    a.PostCode,
                    a.CurrentAddress).Value);
                
                return new Customer4A4(customerData.CustomerId,
                    nameResult.Value,
                    dobResult.Value,
                    idDocumentResult.Value,
                    addresses);
            }
        }

    }
}