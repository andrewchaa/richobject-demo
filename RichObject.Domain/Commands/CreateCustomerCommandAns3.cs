using System;
using System.Collections.Generic;
using MediatR;
using RichObject.Domain.CommandHandlers;
using RichObject.Domain.Models;

namespace RichObject.Domain.Commands
{
    public class CreateCustomerCommandAns3 : IRequest<OperationResponse<Guid>>
    {
        public Customer3Ans Customer { get; }

        public CreateCustomerCommandAns3(Customer3Ans customer)
        {
            Customer = customer;
        }
    }
}