using System.Collections.Generic;
using System.Linq;
using RichObject.Domain.Commands;

namespace RichObject.Domain.Values
{
    public class CustomerName
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Title { get; }

        private CustomerName(string title, 
            string firstName, 
            string lastName)
        {
            Title = title;
            FirstName = firstName;
            LastName = lastName;
        }


        public static OperationResponse<CustomerName> Create(string title, 
            string firstName, 
            string lastName)
        {
            var errorMessages = new List<string>();
            if (string.IsNullOrEmpty(title)) 
                errorMessages.Add($"{nameof(title)} is empty");
            if (string.IsNullOrEmpty(firstName)) 
                errorMessages.Add($"{nameof(firstName)} is empty");
            if (string.IsNullOrEmpty(lastName)) 
                errorMessages.Add($"{nameof(lastName)} is empty");

            if (errorMessages.Any())
            {
                return OperationResponse<CustomerName>.ValidationFailure(errorMessages);
            }

            return OperationResponse<CustomerName>.Success(
                new CustomerName(title, firstName, lastName));

        }
    }
}