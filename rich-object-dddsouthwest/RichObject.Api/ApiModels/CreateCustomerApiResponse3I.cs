using System;
using RichObject.Domain.Models;

namespace RichObject.Api.ApiModels
{
    public class CreateCustomerApiResponse3I
    {
        public Guid CustomerId { get; }
        public CreateCustomerApiResponse3I(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}