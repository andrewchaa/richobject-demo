using FluentValidation;
using RichObject.Api.ApiModels;

namespace RichObject.Api.Validators
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.CountryOfBirth).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.IdDocumentNumber).NotEmpty();
            RuleFor(x => x.IdDocumentType).NotEmpty();
            RuleFor(x => x.VatCountry).NotEmpty().When(x => !string.IsNullOrEmpty(x.VatNumber));
            RuleFor(x => x.VatNumber).NotEmpty().When(x => x.VatCountry > 0);

            RuleFor(x => x.Address).SetValidator(new AddressValidator());
        }
    }
}