using layerEcommerce.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace layerEcommerce.EntityFrameworkCore.EntityTypeConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", layerEcommerceConsts.DbSchema);

            builder.ConfigureByConvention();

            // Properties
            builder.Property(x => x.SKU)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.NameAr)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.Description)
                .HasMaxLength(2000);

            builder.Property(x => x.DescriptionAr)
                .HasMaxLength(2000);

            builder.Property(x => x.ShortDescription)
                .HasMaxLength(512);

            builder.Property(x => x.ShortDescriptionAr)
                .HasMaxLength(512);

            builder.Property(x => x.Price)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            // Relationships
            builder.HasOne(x => x.Category)
                   .WithMany(c=>c.Products)
                   .HasForeignKey(x => x.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
