using System;
using System.Collections.Generic;

namespace RichObject.Domain.Models
{
    public class Customer2
    {
        public Guid CustomerId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string MiddleName { get; }
        public string Title { get; }
        public Address2 Address { get; }
        public IEnumerable<Address2> Addresses { get; }
        public DateTime DateOfBirth { get; }
        public string CountryOfBirth { get; }
        public string IdDocumentType { get; }
        public string IdDocumentNumber { get; }
        public string VatNumber { get; }
        public string VatCountry { get; }

        private Customer2(Guid customerId,
            string firstName,
            string lastName,
            string middleName,
            string title,
            Address2 address,
            DateTime dateOfBirth,
            string countryOfBirth,
            string idDocumentType,
            string idDocumentNumber,
            string vatNumber,
            string vatCountry)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Title = title;
            Address = address;
            DateOfBirth = dateOfBirth;
            CountryOfBirth = countryOfBirth;
            IdDocumentType = idDocumentType;
            IdDocumentNumber = idDocumentNumber;
            VatNumber = vatNumber;
            VatCountry = vatCountry;
        }

        public static Customer2 Create(Guid customerId,
            string firstName, 
            string lastName, 
            string middleName, 
            string title, 
            Address2 address,
            DateTime dateOfBirth, 
            string countryOfBirth, 
            string idDocumentType, 
            string idDocumentNumber, 
            string vatNumber, 
            string vatCountry)
        {
            return new Customer2(customerId, 
                firstName, 
                lastName,
                middleName,
                title,
                address,
                dateOfBirth,
                countryOfBirth,
                idDocumentType,
                idDocumentNumber,
                vatNumber,
                vatCountry
                );
        }
    }
}