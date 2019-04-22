namespace RichObject.Domain
{
    public class AddressV2
    {
        public string HouseNoOrName { get; }
        public string Street { get; }
        public string City { get; }
        public string County { get; }
        public string PostCode { get; }

        public AddressV2(string houseNoOrName, string street, string city, string county, string postCode)
        {
            HouseNoOrName = houseNoOrName;
            Street = street;
            City = city;
            County = county;
            PostCode = postCode;
        }

    }
}