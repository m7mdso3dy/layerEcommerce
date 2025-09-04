using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace layerEcommerce.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class layerEcommerceDbContextFactory : IDesignTimeDbContextFactory<layerEcommerceDbContext>
{
    public layerEcommerceDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        layerEcommerceEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<layerEcommerceDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new layerEcommerceDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../layerEcommerce.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
