using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RichObject.Domain.Commands;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Repositories;

namespace RichObject.Domain.CommandHandlers
{
    public class CreateCustomerCommand3AHandler : IRequestHandler<CreateCustomerCommand3A, 
        OperationResult<Guid>>
    {
        private readonly ICustomerRepository3A _customerRepository;

        public CreateCustomerCommand3AHandler(ICustomerRepository3A customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public async Task<OperationResult<Guid>> Handle(CreateCustomerCommand3A command, 
            CancellationToken cancellationToken)
        {
            var exist = await _customerRepository.Exist(command.Customer.CustomerId);
            if (exist)
                return OperationResult<Guid>.Conflict();

            await _customerRepository.Save(command.Customer);
            return OperationResult<Guid>.Success(command.Customer.CustomerId);
        }
    }
}