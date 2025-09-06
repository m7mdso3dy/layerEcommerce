using layerEcommerce.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace layerEcommerce.EntityFrameworkCore.EntityTypeConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories",layerEcommerceConsts.DbSchema);

            builder.ConfigureByConvention();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(x => x.NameAr)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(x => x.Description)
                .HasMaxLength(512);

            builder.Property(x => x.DescriptionAr)
                .HasMaxLength(512);
        }
    }
}
