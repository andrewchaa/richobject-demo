using System;
using System.Collections;
using System.Collections.Generic;
using MediatR;
using RichObject.Domain.CommandHandlers;

namespace RichObject.Domain.Commands
{
    public class CreateCustomerCommand1 : IRequest<CreateCustomerCommandResponse1>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public CreateAddressCommand1 Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNumber { get; set; }
    }
}