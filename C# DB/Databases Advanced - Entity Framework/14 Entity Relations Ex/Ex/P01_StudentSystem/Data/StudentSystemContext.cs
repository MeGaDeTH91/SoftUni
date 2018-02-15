namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;

    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentId);

                entity.Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100);

                entity.Property(x => x.PhoneNumber)
                    .IsRequired(false)
                    .IsUnicode(false)
                    .HasColumnType("CHAR(10)");

                entity.Property(x => x.RegisteredOn)
                    .IsRequired();

                //entity.Property(x => x.Birthday)
                //    .IsRequired(false);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(x => x.HomeworkId);

                entity.Property(x => x.Content)
                .IsRequired()
                .IsUnicode(false);

                entity.Property(x => x.ContentType)
                .IsRequired();

                entity.Property(x => x.SubmissionTime)
                .IsRequired();

                entity.HasOne(x => x.Course)
                .WithMany(x => x.HomeworkSubmissions)
                .HasForeignKey(x => x.CourseId);

                entity.HasOne(x => x.Student)
                .WithMany(x => x.HomeworkSubmissions)
                .HasForeignKey(x => x.StudentId);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(x => x.CourseId);

                entity.Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(80);

                entity.Property(x => x.Description)
                    .IsRequired(false)
                    .IsUnicode();

                entity.Property(x => x.StartDate)
                .IsRequired();

                entity.Property(x => x.EndDate)
                .IsRequired();

                entity.Property(x => x.Price)
                .IsRequired();
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(x => x.ResourceId);

                entity.Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);

                entity.Property(x => x.Url)
                .IsRequired()
                .IsUnicode(false);

                entity.Property(x => x.ResourceType)
                .IsRequired();

                entity.HasOne(x => x.Course)
                .WithMany(x => x.Resources)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<StudentCourse>(entity => 
            {
                entity.HasKey(x => new { x.StudentId, x.CourseId });

                entity.HasOne(x => x.Student)
                .WithMany(x => x.CourseEnrollments)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Course)
                .WithMany(x => x.StudentsEnrolled)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
