using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RichObject.Domain.Models;
using RichObject.Domain.Queries;
using RichObject.Domain.Repositories;

namespace RichObject.Domain.QueryHandlers
{
    public class GetCustomerQueryHandler1A : IRequestHandler<GetCustomerQuery1A, Customer1A>
    {
        private readonly ICustomerRepository1A _customerRepository;

        public GetCustomerQueryHandler1A(ICustomerRepository1A customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public async Task<Customer1A> Handle(GetCustomerQuery1A query, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.Get(query.CustomerId);

            return customer;
        }
    }
}