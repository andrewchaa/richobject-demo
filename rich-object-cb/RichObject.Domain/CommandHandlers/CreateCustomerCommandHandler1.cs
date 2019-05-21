using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RichObject.Domain.Commands;
using RichObject.Domain.Models;
using RichObject.Domain.Repositories;

namespace RichObject.Domain.CommandHandlers
{
    public class CreateCustomerCommandHandler1 : 
        IRequestHandler<CreateCustomerCommand1, CreateCustomerCommandResponse1>
    {
        private readonly ICustomerRepository3I _customerRepository;

        public CreateCustomerCommandHandler1(ICustomerRepository3I customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public async Task<CreateCustomerCommandResponse1> Handle(CreateCustomerCommand1 command, 
            CancellationToken cancellationToken)
        {
            var response = new CreateCustomerCommandResponse1();
            
            var errorMessages = new List<string>();
            if (string.IsNullOrEmpty(command.Title))
                errorMessages.Add($"{nameof(command.Title)} is empty");
            if (string.IsNullOrEmpty(command.FirstName))
                errorMessages.Add($"{nameof(command.FirstName)} is empty");
            if (string.IsNullOrEmpty(command.LastName))
                errorMessages.Add($"{nameof(command.LastName)} is empty");

            if (errorMessages.Any())
            {
                response.ErrorType = ErrorType.ValidationError;
                response.ErrorMessages = errorMessages;
                response.Success = false;
                return response;
            }

            var customerData = Mapper.Map<CustomerData3I>(command);
            await _customerRepository.Insert(customerData);

            response = Mapper.Map<CreateCustomerCommandResponse1>(customerData);
            response.Success = true;
            return response;
        }
    }
}