using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RichObject.Domain.Commands;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Repositories;

namespace RichObject.Domain.CommandHandlers
{
    public class ChangeCurrentAddressCommand4A4Handler : 
        IRequestHandler<ChangeCurrentAddressCommand4A, OperationResult<Unit>>
    {
        private readonly ICustomerRepository4A4 _customerRepository;

        public ChangeCurrentAddressCommand4A4Handler(ICustomerRepository4A4 customerRepository,
            IMediator mediator)
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
            await _customerRepository.Save(customer);
            
            
            return OperationResult<Unit>.Success(Unit.Value);
        }
    }
}