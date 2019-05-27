using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RichObject.Domain.Commands;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Repositories;

namespace RichObject.Domain.CommandHandlers
{
    /// <summary>
    /// No need of simple validations as they are done by domain models
    /// </summary>

    public class CreateCustomerCommandHandler3 : IRequestHandler<CreateCustomerCommand3, OperationResult<Guid>>
    {
        private readonly ICustomerRepository3 _customerRepository;

        public CreateCustomerCommandHandler3(ICustomerRepository3 customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public async Task<OperationResult<Guid>> Handle(CreateCustomerCommand3 command, 
            CancellationToken cancellationToken)
        {
            await _customerRepository.Insert(command.Customer);

            return OperationResult<Guid>.Success(command.Customer.CustomerId);
        }
    }
}