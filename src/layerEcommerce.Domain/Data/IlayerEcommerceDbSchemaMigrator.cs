using System.Threading.Tasks;

namespace layerEcommerce.Data;

public interface IlayerEcommerceDbSchemaMigrator
{
    Task MigrateAsync();
}
