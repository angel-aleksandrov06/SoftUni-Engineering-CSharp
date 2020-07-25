using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Config;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        {

        }

        public SalesContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connection.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(en =>
            {
                en.Property(e => e.Name)
                .IsUnicode();

                en.Property(e => e.Description)
                .HasDefaultValue("No Description");
            });

            modelBuilder.Entity<Customer>(en =>
            {
                en.Property(e => e.Name)
                .IsUnicode();

                en.Property(e => e.Email)
                .IsUnicode(false);

                en.Property(e => e.CreditCardNumber)
                .IsUnicode(false);

            });

            modelBuilder.Entity<Store>(en =>
            {
                en.Property(e => e.Name)
                .IsUnicode();
            });

            modelBuilder.Entity<Sale>(en =>
            {
                en.Property(e => e.Date)
                .HasDefaultValueSql("GetDate()");
            });
        }
    }
}
