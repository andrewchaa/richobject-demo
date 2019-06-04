using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RichObject.Domain.Commands;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Models;
using RichObject.Domain.Repositories;

namespace RichObject.Domain.CommandHandlers
{
    public class CreateCustomerCommand3IHandler : IRequestHandler<CreateCustomerCommand3I, 
        OperationResult<Guid>>
    {
        private readonly ICustomerRepository3I _customerRepository;

        public CreateCustomerCommand3IHandler(ICustomerRepository3I customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public async Task<OperationResult<Guid>> Handle(CreateCustomerCommand3I command, 
            CancellationToken cancellationToken)
        {
            var errorMessages = new List<string>();
            if (string.IsNullOrEmpty(command.Customer.FirstName)) 
                errorMessages.Add($"{nameof(command.Customer.FirstName)} is empty");
            if (string.IsNullOrEmpty(command.Customer.LastName)) 
                errorMessages.Add($"{nameof(command.Customer.LastName)} is empty");
            if (string.IsNullOrEmpty(command.Customer.Title)) 
                errorMessages.Add($"{nameof(command.Customer.Title)} is empty");

            var age = DateTime.Today.Year - command.Customer.DateOfBirth.Year;
            if (command.Customer.DateOfBirth.Date > DateTime.Today.AddYears(-age)) age--;
            if (age < 18)
                errorMessages.Add($"The applicant's age must be at least 18");

            var exist = await _customerRepository.Exist(command.Customer.CustomerId);
            if (exist)
                return OperationResult<Guid>.Conflict();

            await _customerRepository.Save(command.Customer);
            return OperationResult<Guid>.Success(command.Customer.CustomerId);
        }
    }
}