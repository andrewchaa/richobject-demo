using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RichObject.Domain.Models;
using RichObject.Domain.Queries;
using RichObject.Domain.Repositories;

namespace RichObject.Domain.QueryHandlers
{
    public class GetCustomerQueryHandler1I : IRequestHandler<GetCustomerQuery1I, Customer1I>
    {
        private readonly ICustomerRepository1I _customerRepository;

        public GetCustomerQueryHandler1I(ICustomerRepository1I customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public async Task<Customer1I> Handle(GetCustomerQuery1I query, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.Get(query.CustomerId);

            return customer;
        }
    }
}