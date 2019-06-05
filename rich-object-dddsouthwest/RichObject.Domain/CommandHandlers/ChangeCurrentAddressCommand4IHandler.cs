using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RichObject.Domain.Commands;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Repositories;

namespace RichObject.Domain.CommandHandlers
{
    public class ChangeCurrentAddressCommand4IHandler : 
        IRequestHandler<ChangeCurrentAddressCommand4I, OperationResult<Unit>>
    {
        private readonly ICustomerRepository4I _customerRepository;
        private readonly IAddressRepository4I _addressRepository;

        public ChangeCurrentAddressCommand4IHandler(ICustomerRepository4I customerRepository,
            IAddressRepository4I addressRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
        }
        
        public async Task<OperationResult<Unit>> Handle(ChangeCurrentAddressCommand4I command, 
            CancellationToken cancellationToken)
        {
            var exist = await _customerRepository.Exist(command.CustomerId);
            if (!exist)
                return OperationResult<Unit>.NotFound();

            var addresses = await _addressRepository.List(command.CustomerId);
            var existingCurrentAddress = addresses.Single(a => a.CurrentAddress);
            existingCurrentAddress.SetCurrentAddress(false);

            await _addressRepository.Update(command.CustomerId, existingCurrentAddress);
            await _addressRepository.Insert(command.CustomerId, command.Address);
            
            return OperationResult<Unit>.Success(Unit.Value);
        }
    }
}