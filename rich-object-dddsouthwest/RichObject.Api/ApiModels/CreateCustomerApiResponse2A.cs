using System;
using RichObject.Domain.Models;

namespace RichObject.Api.ApiModels
{
    public class CreateCustomerApiResponse2A
    {
        public Guid CustomerId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Title { get; }

        public CreateCustomerApiResponse2A(Customer2A customer)
        {
            CustomerId = customer.CustomerId;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Title = customer.Title;
        }
    }
}