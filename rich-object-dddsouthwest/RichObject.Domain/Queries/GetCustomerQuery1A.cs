using System;
using MediatR;
using RichObject.Domain.Models;

namespace RichObject.Domain.Queries
{
    public class GetCustomerQuery1A : IRequest<Customer1A>
    {
        public Guid CustomerId { get; }

        public GetCustomerQuery1A(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}