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
    /// Validation that requires DB Check
    /// Domain Model with Behaviour
    /// </summary>
    public class ChangeCustomerAddressCommandHandler4 : IRequestHandler<ChangeCustomerAddressCommand4, OperationResult<Unit>>
    {
        private readonly ICustomerRepository4 _customerRepository;
        private readonly IAddressRepository4 _addressRepository;

        public ChangeCustomerAddressCommandHandler4(ICustomerRepository4 customerRepository,
            IAddressRepository4 addressRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
        }
        
        public async Task<OperationResult<Unit>> Handle(ChangeCustomerAddressCommand4 command, 
            CancellationToken cancellationToken)
        {
            // repository factory
            var customer = await _customerRepository.Get(command.CustomerId, _addressRepository);
            if (customer == null)
                return OperationResult<Unit>.NotFound();

            await customer.ChangeAddress(command.Address);
            
            return OperationResult<Unit>.Success(Unit.Value);
        }
    }
}