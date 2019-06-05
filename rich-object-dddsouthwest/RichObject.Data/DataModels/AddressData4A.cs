using System;

namespace RichObject.Data.DataModels
{
    public class AddressData4A
    {
        public Guid AddressId { get; set; }
        public bool CurrentAddress { get; set; }
        public string HouseNoOrName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
    }
}