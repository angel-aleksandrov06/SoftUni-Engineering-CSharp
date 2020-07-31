namespace PetStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Common;
    using PetStore.Models;
    public class ProductEntityConfiguration
        : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasAlternateKey(p => p.Name);

            builder
                .Property(p => p.Name)
                .HasMaxLength(GlobalConstants.ProductNameMaxLength)
                .IsUnicode(true);
        }
    }
}
