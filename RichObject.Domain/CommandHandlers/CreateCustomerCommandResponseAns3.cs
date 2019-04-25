using System;
using System.Collections.Generic;
using RichObject.Domain.Models;

namespace RichObject.Domain.CommandHandlers
{
    public class CreateCustomerCommandResponseAns3
    {
        public Customer3Ans Customer { get; }

        public CreateCustomerCommandResponseAns3(Customer3Ans customer)
        {
            Customer = customer;
        }
    }
}