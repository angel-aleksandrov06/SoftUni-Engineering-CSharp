namespace PetStore.Data
{
    using Microsoft.EntityFrameworkCore;
    using PetStore.Common;

    class PetStoreDbContex : DbContext
    {
        public PetStoreDbContex()
        {

        }

        public PetStoreDbContex(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConfiguration.DefConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetStoreDbContex).Assembly);
        }
    }
}
