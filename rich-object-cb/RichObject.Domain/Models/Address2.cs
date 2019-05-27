using System.Collections.Generic;
using System.Linq;
using RichObject.Domain.Infrastructure;

namespace RichObject.Domain.Models
{
    public class Address2
    {
        public string HouseNoOrName { get; }
        public string Street { get; }
        public string City { get; }
        public string County { get; }
        public string PostCode { get; }

        private Address2(string houseNoOrName,
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

        public static Address2 Create(string houseNoOrName, 
            string street, 
            string city, 
            string county, 
            string postCode)
        {
            var errorMessages = new Dictionary<string, string>();

            return new Address2(houseNoOrName,
            street,
            city,
            county,
            postCode);
        }
    }
}