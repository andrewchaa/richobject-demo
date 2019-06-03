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
    public class CreateCustomerCommandHandler3I : 
        IRequestHandler<CreateCustomerCommand2I, CreateCustomerCommandResponse2I>
    {
        private readonly ICustomerRepository3I _customerRepository;

        public CreateCustomerCommandHandler3I(ICustomerRepository3I customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public async Task<CreateCustomerCommandResponse2I> Handle(CreateCustomerCommand2I command, 
            CancellationToken cancellationToken)
        {
            var response = new CreateCustomerCommandResponse2I();
            
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

            response = Mapper.Map<CreateCustomerCommandResponse2I>(customerData);
            response.Success = true;
            return response;
        }
    }
}