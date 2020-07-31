namespace PetStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Models;

    public class ClientProductEntityConfiguration
        : IEntityTypeConfiguration<ClientProduct>
    {
        public void Configure(EntityTypeBuilder<ClientProduct> builder)
        {
            builder
                .HasKey(cp => 
                    new { cp.ClientId, cp.ProductId });
        }
    }
}
