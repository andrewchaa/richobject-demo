namespace RichObject.Domain.Models
{
    public class AddressV2
    {
        public string HouseNoOrName { get; }
        public string Street { get; }
        public string City { get; }
        public string County { get; }
        public string PostCode { get; }
        public bool CurrentAddress { get;  }

        public AddressV2(string houseNoOrName, 
            string street, 
            string city, 
            string county, 
            string postCode,
            bool currentAddress)
        {
            HouseNoOrName = houseNoOrName;
            Street = street;
            City = city;
            County = county;
            PostCode = postCode;
            CurrentAddress = currentAddress;
        }

    }
}