using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RichObject.Domain.Commands;
using RichObject.Domain.Repositories;

namespace RichObject.Domain.CommandHandlers
{
    public class ChangeCurrentAddressCommandHandler5I : 
        IRequestHandler<ChangeCurrentAddressCommand5I, OperationResult<Unit>>
    {
        private readonly ICustomerRepository5I _customerRepository;
        private readonly IAddressRepository5I _addressRepository;

        public ChangeCurrentAddressCommandHandler5I(ICustomerRepository5I customerRepository,
            IAddressRepository5I addressRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
        }
        
        public async Task<OperationResult<Unit>> Handle(ChangeCurrentAddressCommand5I command, 
            CancellationToken cancellationToken)
        {
            var exist = await _customerRepository.Exist(command.CustomerId);
            if (!exist)
                return OperationResult<Unit>.NotFound();

            var addresses = await _addressRepository.List(command.CustomerId);
            var existingCurrentAddress = addresses.Single(a => a.CurrentAddress);
            existingCurrentAddress.SetCurrentAddress(false);

            await _addressRepository.Update(existingCurrentAddress);
            await _addressRepository.Insert(command.Address);
            
            return OperationResult<Unit>.Success(Unit.Value);
        }
    }
}