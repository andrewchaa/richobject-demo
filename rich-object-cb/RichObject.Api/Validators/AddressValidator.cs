using FluentValidation;
using RichObject.Api.ApiModels;

namespace RichObject.Api.Validators
{
    public class AddressValidator : AbstractValidator<AddressRequest>
    {
        public AddressValidator()
        {
            RuleFor(x => x.HouseNoOrName).NotEmpty();
            RuleFor(x => x.Street).NotEmpty();
            RuleFor(x => x.City).NotEmpty().When(x => string.IsNullOrEmpty(x.County));
            RuleFor(x => x.County).NotEmpty().When(x => string.IsNullOrEmpty(x.City));
        }
    }
}