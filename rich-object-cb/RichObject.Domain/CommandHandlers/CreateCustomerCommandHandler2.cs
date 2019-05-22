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
    /// Command wraps Customer domain model
    /// Repository accepts Customer
    /// </summary>

    public class CreateCustomerCommandHandler2 : IRequestHandler<CreateCustomerCommand2, OperationResult<Guid>>
    {
        private readonly ICustomerRepository2 _customerRepository;

        public CreateCustomerCommandHandler2(ICustomerRepository2 customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public async Task<OperationResult<Guid>> Handle(CreateCustomerCommand2 command, 
            CancellationToken cancellationToken)
        {
            var errorMessages = new List<string>();
            if (string.IsNullOrEmpty(command.Customer.Title))
                errorMessages.Add($"{nameof(command.Customer.Title)} is empty");
            if (string.IsNullOrEmpty(command.Customer.FirstName))
                errorMessages.Add($"{nameof(command.Customer.FirstName)} is empty");
            if (string.IsNullOrEmpty(command.Customer.LastName))
                errorMessages.Add($"{nameof(command.Customer.LastName)} is empty");

            if (errorMessages.Any())
            {
                return OperationResult<Guid>.ValidationFailure(errorMessages);
            }

            await _customerRepository.Insert(command.Customer);

            return OperationResult<Guid>.Success(command.Customer.CustomerId);
        }
    }
}