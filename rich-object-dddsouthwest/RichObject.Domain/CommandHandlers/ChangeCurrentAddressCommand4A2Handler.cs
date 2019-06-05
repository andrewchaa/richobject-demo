using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RichObject.Domain.Commands;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Repositories;

namespace RichObject.Domain.CommandHandlers
{
    public class ChangeCurrentAddressCommand4A2Handler : 
        IRequestHandler<ChangeCurrentAddressCommand4A, OperationResult<Unit>>
    {
        private readonly ICustomerAddressRepository4A2 _customerAddressRepository;

        public ChangeCurrentAddressCommand4A2Handler(ICustomerAddressRepository4A2 customerAddressRepository)
        {
            _customerAddressRepository = customerAddressRepository;
        }
        
        public async Task<OperationResult<Unit>> Handle(ChangeCurrentAddressCommand4A command, 
            CancellationToken cancellationToken)
        {
            // repository factory
            var customerAddress = await _customerAddressRepository.Get(command.CustomerId);
            if (customerAddress == null)
                return OperationResult<Unit>.NotFound();

            customerAddress.ChangeCurrentAddress(command.Address);
            await _customerAddressRepository.Save(customerAddress);
            
            return OperationResult<Unit>.Success(Unit.Value);
        }
    }
}