using System;
using System.Collections.Generic;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Models;

namespace RichObject.Domain.Queries
{
    public class GetCustomerQuery2IResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public IEnumerable<Address1I> Addresses { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNumber { get; set; }
        
        public OperationStatus Status { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; }

    }
}