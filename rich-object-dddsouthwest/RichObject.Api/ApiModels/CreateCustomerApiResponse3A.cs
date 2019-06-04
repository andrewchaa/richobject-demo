using System;

namespace RichObject.Api.ApiModels
{
    public class CreateCustomerApiResponse3A
    {
        public Guid CustomerId { get; }

        public CreateCustomerApiResponse3A(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}