using System;

namespace RichObject.Api.ApiModels
{
    public class CreateCustomerResponse2A
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
    }
}