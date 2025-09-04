using layerEcommerce.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace layerEcommerce.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(layerEcommerceEntityFrameworkCoreModule),
    typeof(layerEcommerceApplicationContractsModule)
)]
public class layerEcommerceDbMigratorModule : AbpModule
{
}
