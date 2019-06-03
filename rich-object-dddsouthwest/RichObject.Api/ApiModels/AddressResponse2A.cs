using RichObject.Domain.Models;

namespace RichObject.Api.ApiModels
{
    public class AddressResponse2A
    {
        public string HouseNoOrName { get; }
        public string Street { get; }
        public string City { get; }
        public string County { get; }
        public string PostCode { get; }

        public AddressResponse2A(Address2A address)
        {
            HouseNoOrName = address.HouseNoOrName;
            Street = address.Street;
            City = address.City;
            County = address.County;
            PostCode = address.PostCode;
        }
    }
}