using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Models;
using RichObject.Domain.Queries;
using RichObject.Domain.Repositories;

namespace RichObject.Domain.QueryHandlers
{
    public class GetCustomerQuery2IHandler : IRequestHandler<GetCustomerQuery2I, GetCustomerQuery2IResponse>
    {
        private readonly ICustomerRepository2I _customerRepository;

        public GetCustomerQuery2IHandler(ICustomerRepository2I customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public async Task<GetCustomerQuery2IResponse> Handle(GetCustomerQuery2I query, 
            CancellationToken cancellationToken)
        {
            var customerData = await _customerRepository.Get(query.CustomerId);
            if (customerData == null)
            {
                var response = new GetCustomerQuery2IResponse();
                response.Status = OperationStatus.NotFound;
                return response;
            }
            
            var customer = Mapper.Map<GetCustomerQuery2IResponse>(customerData);
            return customer;
        }
    }
}