using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RichObject.Domain.Commands;
using RichObject.Domain.Repositories;

namespace RichObject.Domain.CommandHandlers
{
    public class ChangeCurrentAddressCommandHandler5A : 
        IRequestHandler<ChangeCurrentAddressCommand5A, OperationResult<Unit>>
    {
        private readonly ICustomerRepository5A _customerRepository;
        private readonly IAddressRepository5A _addressRepository;

        public ChangeCurrentAddressCommandHandler5A(ICustomerRepository5A customerRepository,
            IAddressRepository5A addressRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
        }
        
        public async Task<OperationResult<Unit>> Handle(ChangeCurrentAddressCommand5A command, 
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