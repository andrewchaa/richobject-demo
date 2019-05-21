using System;
using System.Collections.Generic;
using RichObject.Domain.Models;

namespace RichObject.Domain.CommandHandlers
{
    public class CreateCustomerCommandResponse3A
    {
        public Customer3A Customer { get; }

        public CreateCustomerCommandResponse3A(Customer3A customer)
        {
            Customer = customer;
        }
    }
}