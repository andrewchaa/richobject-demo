using System.Collections.Generic;
using System.Linq;
using RichObject.Domain.Infrastructure;

namespace RichObject.Domain.Models
{
    public class Address3
    {
        public string HouseNoOrName { get; }
        public string Street { get; }
        public string City { get; }
        public string County { get; }
        public string PostCode { get; }

        private Address3(string houseNoOrName,
            string street,
            string city,
            string county,
            string postCode)
        {
            HouseNoOrName = houseNoOrName;
            Street = street;
            City = city;
            County = county;
            PostCode = postCode;
        }

        public static OperationResult<Address3> Create(string houseNoOrName, 
            string street, 
            string city, 
            string county, 
            string postCode)
        {
            var errorMessages = new Dictionary<string, string>();

            if (string.IsNullOrEmpty(houseNoOrName)) errorMessages.Add(nameof(houseNoOrName), "Cannot be empty");
            if (string.IsNullOrEmpty(street)) errorMessages.Add(nameof(street), "Cannot be empty");
            if (string.IsNullOrEmpty(city) && string.IsNullOrEmpty(county))
            {
                errorMessages.Add($"{nameof(city)}{nameof(county)}", "Either city or country must be provided");
            }

            if (errorMessages.Any())
                return OperationResult<Address3>.ValidationFailure(errorMessages);

            return OperationResult<Address3>.Success(new Address3(houseNoOrName,
            street,
            city,
            county,
            postCode));
        }
    }
}