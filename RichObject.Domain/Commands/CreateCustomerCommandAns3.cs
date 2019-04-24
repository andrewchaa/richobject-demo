using System;
using System.Collections.Generic;
using MediatR;
using RichObject.Domain.CommandHandlers;
using RichObject.Domain.Models;

namespace RichObject.Domain.Commands
{
    public class CreateCustomerCommandAns3 : IRequest<CreateCustomerCommandResponseAns3>
    {
        public CustomerAns3 Customer { get; }

        public CreateCustomerCommandAns3(CustomerAns3 customer)
        {
            Customer = customer;
        }
    }
}