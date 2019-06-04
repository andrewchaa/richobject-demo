using System;
using RichObject.Domain.Models;

namespace RichObject.Api.ApiModels
{
    public class CreateCustomerApiResponse2A
    {
        public Guid CustomerId { get; }

        public CreateCustomerApiResponse2A(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}