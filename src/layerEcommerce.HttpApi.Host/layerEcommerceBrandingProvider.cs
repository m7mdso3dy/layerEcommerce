using Microsoft.Extensions.Localization;
using layerEcommerce.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace layerEcommerce;

[Dependency(ReplaceServices = true)]
public class layerEcommerceBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<layerEcommerceResource> _localizer;

    public layerEcommerceBrandingProvider(IStringLocalizer<layerEcommerceResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
