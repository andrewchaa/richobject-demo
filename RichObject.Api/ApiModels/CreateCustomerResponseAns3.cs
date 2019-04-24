using System;

namespace RichObject.Api.ApiModels
{
    public class CreateCustomerResponseAns3
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
    }
}