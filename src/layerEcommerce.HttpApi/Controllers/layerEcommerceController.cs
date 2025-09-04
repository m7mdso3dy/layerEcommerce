using layerEcommerce.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace layerEcommerce.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class layerEcommerceController : AbpControllerBase
{
    protected layerEcommerceController()
    {
        LocalizationResource = typeof(layerEcommerceResource);
    }
}
