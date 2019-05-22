using System;
using System.Collections.Generic;
using RichObject.Domain.Infrastructure;

namespace RichObject.Domain.Models
{
    public class Customer3
    {
        public Guid CustomerId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string MiddleName { get; }
        public string Title { get; }
        public Address3 Address { get; }
        public DateTime DateOfBirth { get; }
        public CountryCode CountryOfBirth { get; }
        public string IdDocumentType { get; }
        public string IdDocumentNumber { get; }
        public string VatNumber { get; }
        public CountryCode VatCountry { get; }

        private Customer3(Guid customerId,
            string firstName,
            string lastName,
            string middleName,
            string title,
            Address3 address,
            DateTime dateOfBirth,
            CountryCode countryOfBirth,
            string idDocumentType,
            string idDocumentNumber,
            string vatNumber,
            CountryCode vatCountry)
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

        public static OperationResult<Customer3> Create(Guid customerId,
            string firstName, 
            string lastName, 
            string middleName, 
            string title, 
            Address3 address,
            DateTime dateOfBirth,
            CountryCode countryOfBirth, 
            string idDocumentType, 
            string idDocumentNumber, 
            string vatNumber,
            CountryCode vatCountry)
        {

            return OperationResult<Customer3>.Success(new Customer3(customerId, 
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
                ));
        }
    }
}