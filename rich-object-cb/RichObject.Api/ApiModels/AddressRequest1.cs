namespace RichObject.Api.ApiModels
{
    public class AddressRequest1
    {
        public string HouseNoOrName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public bool CurrentAddress { get; set; }
    }
}