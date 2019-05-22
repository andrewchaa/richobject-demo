using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RichObject.Domain.Infrastructure;
using RichObject.Domain.Repositories;

namespace RichObject.Domain.Models
{
    public class Customer4
    {
        private readonly IAddressRepository4 _addressRepository;
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

        private Customer4(Guid customerId,
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

        private Customer4(Guid customerId,
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
            CountryCode vatCountry, 
            IAddressRepository4 addressRepository) : this(customerId, 
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
            vatCountry)
        {
            _addressRepository = addressRepository;
        }

        public static OperationResult<Customer4> Create(Guid customerId,
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
            CountryCode vatCountry,
            IAddressRepository4 addressRepository
            )
        {

            return OperationResult<Customer4>.Success(new Customer4(customerId, 
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

        public async Task ChangeAddress(Address4 address)
        {
            await _addressRepository.Update(address);
        }
    }
}