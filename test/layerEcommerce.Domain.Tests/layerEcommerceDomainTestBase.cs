using Volo.Abp.Modularity;

namespace layerEcommerce;

/* Inherit from this class for your domain layer tests. */
public abstract class layerEcommerceDomainTestBase<TStartupModule> : layerEcommerceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
