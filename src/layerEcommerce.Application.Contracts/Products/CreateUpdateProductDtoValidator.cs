using FluentValidation;
using Microsoft.Extensions.Localization;
using layerEcommerce.Localization;

namespace layerEcommerce.Products
{
    public class CreateUpdateProductDtoValidator : AbstractValidator<CreateUpdateProductDto>
    {
        public CreateUpdateProductDtoValidator(IStringLocalizer<layerEcommerceResource> localizer)
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage(localizer["ProductNameRequired"])
                .Length(3, 256).WithMessage(localizer["ProductNameLength"]);

            RuleFor(p => p.NameAr)
                .NotEmpty().WithMessage(localizer["ProductNameArRequired"]);

            RuleFor(p => p.SKU)
                .NotEmpty().WithMessage(localizer["ProductSkuRequired"])
                .MaximumLength(64).WithMessage(localizer["ProductSkuLength"]);

            RuleFor(p => p.CategoryId)
                .NotEmpty().WithMessage(localizer["ProductCategoryRequired"]);

            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(0).WithMessage(localizer["ProductPriceNegative"]);

            RuleFor(p => p.Description)
                .MaximumLength(2000).WithMessage(localizer["ProductDescriptionLength"]);

            RuleFor(p => p.ShortDescription)
                .MaximumLength(512).WithMessage(localizer["ProductShortDescriptionLength"]);
        }
    }
}
