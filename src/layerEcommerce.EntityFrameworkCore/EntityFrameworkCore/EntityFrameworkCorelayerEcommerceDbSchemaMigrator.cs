using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using layerEcommerce.Data;
using Volo.Abp.DependencyInjection;

namespace layerEcommerce.EntityFrameworkCore;

public class EntityFrameworkCorelayerEcommerceDbSchemaMigrator
    : IlayerEcommerceDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCorelayerEcommerceDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the layerEcommerceDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<layerEcommerceDbContext>()
            .Database
            .MigrateAsync();
    }
}
