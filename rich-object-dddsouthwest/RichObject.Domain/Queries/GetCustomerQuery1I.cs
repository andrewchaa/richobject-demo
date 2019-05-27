using System;
using MediatR;
using RichObject.Domain.Models;

namespace RichObject.Domain.Queries
{
    public class GetCustomerQuery1I : IRequest<Customer1I>
    {
        public Guid CustomerId { get; }

        public GetCustomerQuery1I(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}