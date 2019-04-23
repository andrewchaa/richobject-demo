namespace RichObject.Domain.CommandHandlers
{
    public class CreateAddressCommandResponseV4
    {
        public string HouseNoOrName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public bool CurrentAddress { get; set;  }
    }
}