namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
            
        }

        public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(en =>
            {
                en.HasKey(s => s.StudentId);

                en.Property(s => s.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(100);

                en.Property(s => s.PhoneNumber)
                .IsRequired(false)
                .IsUnicode(false)
                .HasColumnType("char")
                .HasMaxLength(10);

                en.Property(s => s.Birthday)
                .IsRequired(false);
            });

            modelBuilder.Entity<Course>(en =>
            {
                en.HasKey(c => c.CourseId);

                en.Property(c => c.Name)
                .IsUnicode(true)
                .IsRequired(true)
                .HasMaxLength(80);

                en.Property(c => c.Description)
                .IsRequired(false)
                .IsUnicode(true);
            });

            modelBuilder.Entity<Resource>(en =>
            {
                en.HasKey(r => r.ResourceId);

                en.Property(r => r.Name)
                .IsUnicode(true)
                .HasMaxLength(50);

                en.Property(r => r.Url)
                .IsUnicode(false);

                en.Property(r => r.ResourceType)
                .IsRequired(true);

                en.HasOne(r => r.Course)
                .WithMany(c => c.Resources)
                .HasForeignKey(r => r.CourseId);
            });

            modelBuilder.Entity<Homework>(en =>
            {
                en.HasKey(h => h.HomeworkId);

                en.Property(h => h.Content)
                .IsUnicode(false);

                en.HasOne(h => h.Student)
                .WithMany(s => s.HomeworkSubmissions)
                .HasForeignKey(h => h.StudentId);

                en.HasOne(h => h.Course)
                .WithMany(c => c.HomeworkSubmissions)
                .HasForeignKey(h => h.CourseId);
            });

            modelBuilder.Entity<StudentCourse>(en =>
            {
                en.HasKey(sc => new { sc.StudentId, sc.CourseId });

                en.HasOne(sc => sc.Student)
                .WithMany(s => s.CourseEnrollments)
                .HasForeignKey(sc => sc.StudentId);

                en.HasOne(sc => sc.Course)
                .WithMany(c => c.StudentsEnrolled)
                .HasForeignKey(sc => sc.CourseId);
            });
        }
    }
}
