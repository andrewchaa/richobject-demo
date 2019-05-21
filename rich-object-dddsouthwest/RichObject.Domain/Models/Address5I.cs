using System;
using System.Collections.Generic;
using System.Linq;
using RichObject.Domain.Commands;

namespace RichObject.Domain.Models
{
    public class Address5I
    {
        public Guid AddressId { get; }
        public string HouseNoOrName { get; }
        public string Street { get; }
        public string City { get; }
        public string County { get; }
        public string PostCode { get; }
        public bool CurrentAddress { get; private set; }

        private Address5I(Guid addressId, 
            string houseNoOrName, 
            string street, 
            string city, 
            string county, 
            string postCode,
            bool isCurrentAddress)
        {
            AddressId = addressId;
            HouseNoOrName = houseNoOrName;
            Street = street;
            City = city;
            County = county;
            PostCode = postCode;
            CurrentAddress = isCurrentAddress;
        }

        public void SetCurrentAddress(bool isCurrentAddress)
        {
            CurrentAddress = isCurrentAddress;
        }

        public static OperationResult<Address5I> Create(Guid addressId,
            string houseNoOrName, 
            string street, 
            string city, 
            string county, 
            string postCode,
            bool isCurrentAddress)
        {
            var errorMessages = new List<string>();
            if (string.IsNullOrEmpty(houseNoOrName))
                errorMessages.Add($"{nameof(houseNoOrName)} is empty");
            if (string.IsNullOrEmpty(street))
                errorMessages.Add($"{nameof(street)} is empty");
            if (string.IsNullOrEmpty(city) && string.IsNullOrEmpty(county))
                errorMessages.Add($"One of {nameof(city)} and {nameof(county)} must be present");
            if (string.IsNullOrEmpty(postCode))
                errorMessages.Add($"{nameof(postCode)} is empty");

            if (errorMessages.Any())
                return OperationResult<Address5I>.ValidationFailure(errorMessages);

            return OperationResult<Address5I>.Success(new Address5I(addressId, 
                houseNoOrName,
                street,
                city,
                county,
                postCode,
                isCurrentAddress));
        }
    }
}