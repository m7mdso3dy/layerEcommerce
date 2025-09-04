using layerEcommerce.Localization;
using Volo.Abp.Application.Services;

namespace layerEcommerce;

/* Inherit your application services from this class.
 */
public abstract class layerEcommerceAppService : ApplicationService
{
    protected layerEcommerceAppService()
    {
        LocalizationResource = typeof(layerEcommerceResource);
    }
}
