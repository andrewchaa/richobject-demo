using System;
using System.Collections.Generic;
using RichObject.Domain.Models;

namespace RichObject.Domain.CommandHandlers
{
    public class CreateCustomerCommandResponseAns3
    {
        public CustomerAns3 Customer { get; }

        public CreateCustomerCommandResponseAns3(CustomerAns3 customer)
        {
            Customer = customer;
        }
    }
}