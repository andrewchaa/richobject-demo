using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RichObject.Domain.Commands;
using RichObject.Domain.Repositories;

namespace RichObject.Domain.CommandHandlers
{
    public class CreateCustomerCommandHandler4A : IRequestHandler<CreateCustomerCommand4A, 
        OperationResult<Guid>>
    {
        private readonly ICustomerRepository4A _customerRepository;

        public CreateCustomerCommandHandler4A(ICustomerRepository4A customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public async Task<OperationResult<Guid>> Handle(CreateCustomerCommand4A command, 
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