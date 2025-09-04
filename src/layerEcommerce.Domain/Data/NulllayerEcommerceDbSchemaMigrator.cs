using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace layerEcommerce.Data;

/* This is used if database provider does't define
 * IlayerEcommerceDbSchemaMigrator implementation.
 */
public class NulllayerEcommerceDbSchemaMigrator : IlayerEcommerceDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
