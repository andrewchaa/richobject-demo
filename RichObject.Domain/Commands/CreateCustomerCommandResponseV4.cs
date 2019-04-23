using System;
using System.Collections.Generic;

namespace RichObject.Domain.Commands
{
    public class CreateCustomerCommandResponseV4
    {
        public IEnumerable<string> ErrorMessages { get; set; }
        public bool Success { get; set; }
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
    }
}