using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RichObject.Domain.Commands;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Repositories;

namespace RichObject.Domain.CommandHandlers
{
    public class ChangeCurrentAddressCommand4A1Handler : 
        IRequestHandler<ChangeCurrentAddressCommand4A, OperationResult<Unit>>
    {
        private readonly ICustomerRepository4A1 _customerRepository;

        public ChangeCurrentAddressCommand4A1Handler(ICustomerRepository4A1 customerRepository,
            IAddressRepository4A addressRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public async Task<OperationResult<Unit>> Handle(ChangeCurrentAddressCommand4A command, 
            CancellationToken cancellationToken)
        {
            // repository factory
            var customer = await _customerRepository.Get(command.CustomerId);
            if (customer == null)
                return OperationResult<Unit>.NotFound();

            customer.ChangeCurrentAddress(command.Address);
            await _customerRepository.SaveAddresses(customer);
            
            
            return OperationResult<Unit>.Success(Unit.Value);
        }
    }
}