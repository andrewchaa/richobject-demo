using System;
using MediatR;
using RichObject.Domain.Models;
using RichObject.Domain.Repositories;

namespace RichObject.Domain.Queries
{
    public class GetCustomerQuery2I : IRequest<GetCustomerQuery2IResponse>
    {
        public Guid CustomerId { get; }

        public GetCustomerQuery2I(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}