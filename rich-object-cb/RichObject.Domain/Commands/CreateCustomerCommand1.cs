using System;
using System.Collections;
using System.Collections.Generic;
using MediatR;
using RichObject.Domain.CommandHandlers;

namespace RichObject.Domain.Commands
{
    public class CreateCustomerCommand1 : IRequest<CreateCustomerCommandResponse3I>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public IEnumerable<CreateAddressCommand3I> Addresses { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNumber { get; set; }
    }
}