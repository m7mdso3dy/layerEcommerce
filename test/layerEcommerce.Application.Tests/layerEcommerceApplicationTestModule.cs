using Volo.Abp.Modularity;

namespace layerEcommerce;

[DependsOn(
    typeof(layerEcommerceApplicationModule),
    typeof(layerEcommerceDomainTestModule)
)]
public class layerEcommerceApplicationTestModule : AbpModule
{

}
