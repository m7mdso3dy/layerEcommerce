using Volo.Abp.Modularity;

namespace layerEcommerce;

public abstract class layerEcommerceApplicationTestBase<TStartupModule> : layerEcommerceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
