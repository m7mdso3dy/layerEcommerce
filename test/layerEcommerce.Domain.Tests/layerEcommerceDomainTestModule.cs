using Volo.Abp.Modularity;

namespace layerEcommerce;

[DependsOn(
    typeof(layerEcommerceDomainModule),
    typeof(layerEcommerceTestBaseModule)
)]
public class layerEcommerceDomainTestModule : AbpModule
{

}
