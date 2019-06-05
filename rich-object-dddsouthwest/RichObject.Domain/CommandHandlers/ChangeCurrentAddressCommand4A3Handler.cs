using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RichObject.Domain.Commands;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Repositories;

namespace RichObject.Domain.CommandHandlers
{
    public class ChangeCurrentAddressCommand4A3Handler : 
        IRequestHandler<ChangeCurrentAddressCommand4A, OperationResult<Unit>>
    {
        private readonly ICustomerRepository4A3 _customerRepository;
        private readonly IAddressRepository4A3 _addressRepository;

        public ChangeCurrentAddressCommand4A3Handler(ICustomerRepository4A3 customerRepository,
            IAddressRepository4A3 addressRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
        }
        
        public async Task<OperationResult<Unit>> Handle(ChangeCurrentAddressCommand4A command, 
            CancellationToken cancellationToken)
        {
            // repository factory
            var customer = await _customerRepository.Get(command.CustomerId, _addressRepository);
            if (customer == null)
                return OperationResult<Unit>.NotFound();

            await customer.ChangeCurrentAddress(command.Address);
            
            return OperationResult<Unit>.Success(Unit.Value);
        }
    }
}