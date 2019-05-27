using System.Collections.Generic;
using RichObject.Domain.Models;

namespace RichObject.Domain.Commands
{
    public class CreateAddressCommand1
    {
        public string HouseNoOrName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
    }
}