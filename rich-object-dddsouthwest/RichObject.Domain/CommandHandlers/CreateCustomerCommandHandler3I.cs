using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RichObject.Domain.Commands;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Models;
using RichObject.Domain.Repositories;

namespace RichObject.Domain.CommandHandlers
{
    public class CreateCustomerCommandHandler3I : IRequestHandler<CreateCustomerCommand3I, 
        OperationResult<Guid>>
    {
        private readonly ICustomerRepository3I _customerRepository;

        public CreateCustomerCommandHandler3I(ICustomerRepository3I customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public async Task<OperationResult<Guid>> Handle(CreateCustomerCommand3I command, 
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