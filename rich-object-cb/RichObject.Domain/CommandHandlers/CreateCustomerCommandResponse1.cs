using System;
using System.Collections.Generic;
using System.Linq;
using RichObject.Domain.Commands;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Models;

namespace RichObject.Domain.CommandHandlers
{
    public class CreateCustomerCommandResponse1
    {
        public IEnumerable<string> ErrorMessages { get; set; }
        public bool Success { get; set; }
        public ErrorType ErrorType { get; set; }
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public CreateAddressCommandResponse1 Address { get; set; }
        public OperationStatus Result { get; set; }
    }
}