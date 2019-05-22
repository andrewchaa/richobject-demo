using System.Collections.Generic;
using System.Linq;
using RichObject.Domain.Infrastructure;

namespace RichObject.Domain.Models
{
    public class Address4
    {
        public string HouseNoOrName { get; }
        public string Street { get; }
        public string City { get; }
        public string County { get; }
        public string PostCode { get; }

        private Address4(string houseNoOrName,
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

        public static OperationResult<Address4> Create(string houseNoOrName, 
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
                return OperationResult<Address4>.ValidationFailure(errorMessages);

            return OperationResult<Address4>.Success(new Address4(houseNoOrName,
            street,
            city,
            county,
            postCode));
        }
    }
}