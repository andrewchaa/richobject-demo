using System;
using MediatR;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Models;

namespace RichObject.Domain.Queries
{
    public class GetCustomerQuery2A : IRequest<OperationResult<Customer2A>>
    {
        public Guid CustomerId { get; }

        public GetCustomerQuery2A(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}