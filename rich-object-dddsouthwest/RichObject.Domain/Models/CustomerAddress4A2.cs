using System;
using System.Collections.Generic;
using System.Linq;

namespace RichObject.Domain.Models
{
    public class CustomerAddress4A2
    {
        public Guid CustomerId { get; }
        public IList<Address4A> Addresses { get; }

        public CustomerAddress4A2(Guid customerId,
            IList<Address4A> addresses)
        {
            CustomerId = customerId;
            Addresses = addresses;
        }

        public void ChangeCurrentAddress(Address4A address)
        {
            var existingCurrentAddress = Addresses.Single(a => a.CurrentAddress);
            existingCurrentAddress.SetCurrentAddress(false);
            
            Addresses.Add(address);
        }
    }
}