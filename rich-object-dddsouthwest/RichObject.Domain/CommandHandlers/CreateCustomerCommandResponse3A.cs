using System;
using System.Collections.Generic;
using RichObject.Domain.Models;

namespace RichObject.Domain.CommandHandlers
{
    public class CreateCustomerCommandResponse3A
    {
        public Customer2A Customer { get; }

        public CreateCustomerCommandResponse3A(Customer2A customer)
        {
            Customer = customer;
        }
    }
}