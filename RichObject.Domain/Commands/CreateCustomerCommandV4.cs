using System;
using System.Collections;
using System.Collections.Generic;
using MediatR;

namespace RichObject.Domain.Commands
{
    public class CreateCustomerCommandV4 : IRequest<CreateCustomerCommandResponseV4>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public IEnumerable<CreateAddressCommandV4> Addresses { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNumber { get; set; }
    }
}