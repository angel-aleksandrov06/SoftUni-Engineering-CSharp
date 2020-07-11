namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Config;
    using P01_HospitalDatabase.Data.Models;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        public DbSet<Doctor> Doctor { get; set; }

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
            modelBuilder.Entity<Patient>(en =>
            {
                en.HasKey(p => p.PatientId);

                en.Property(p => p.FirstName)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);

                en.Property(p => p.LastName)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);

                en.Property(p => p.Address)
                    .IsUnicode()
                    .HasMaxLength(250);

                en.Property(p => p.Email)
                    .IsUnicode(false)
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<Visitation>(en =>
            {
                en.HasKey(v => v.VisitationId);

                en.Property(v => v.Comments)
                    .IsUnicode()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Diagnose>(en =>
            {
                en.HasKey(d => d.DiagnoseId);

                en.Property(d => d.Name)
                    .IsUnicode()
                    .HasMaxLength(50);

                en.Property(d => d.Comments)
                    .IsUnicode()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Medicament>(en =>
            {
                en.HasKey(m => m.MedicamentId);

                en.Property(m => m.Name)
                    .IsUnicode()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PatientMedicament>(en =>
            {
                en.HasKey(pm => new { pm.PatientId, pm.MedicamentId });
            });

            modelBuilder.Entity<Doctor>(en =>
            {
                en.HasKey(d => d.DoctorId);

                en.Property(d => d.Name)
                    .IsUnicode()
                    .HasMaxLength(100);

                en.Property(d => d.Specialty)
                    .IsUnicode()
                    .HasMaxLength(100);
            });
        }
    }
}
