using EdVision.Retraining.Model;
using Microsoft.EntityFrameworkCore;

namespace EdVision.Retraining.DataLayer {
    public class RetrainingContext : DbContext {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeCompetency> EmployeeCompetencies { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<JobTitleCompetency> JobTitleCompetencies { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Competency> Competencies { get; set; }
        public DbSet<Direction> Directions { get; set; }


        public RetrainingContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            //var competency = modelBuilder.Entity<Competency>();
            //competency.HasKey(c => c.Id);
            //competency.Property(c => c.Id).ValueGeneratedOnAdd();

            var course = modelBuilder.Entity<Course>();
            course.HasOne(c => c.Direction).WithOne().HasPrincipalKey<Direction>(d => d.Id);
            course.HasMany(c => c.RequiredCompetencies).WithOne().HasPrincipalKey(c => c.Id);
            course.HasMany(c => c.OutputCompetencies).WithOne().HasPrincipalKey(c => c.Id);

            var coursePassingResult = modelBuilder.Entity<CoursePassingResult>();
            //coursePassingResult.Property(c => c.Id).ValueGeneratedOnAdd();
            coursePassingResult.HasOne(m => m.Course).WithOne().HasPrincipalKey<Course>(c => c.Id);

            var direction = modelBuilder.Entity<Direction>();
            //direction.Property(d => d.Id).ValueGeneratedOnAdd();
            direction.HasKey(d => d.Id);

            var employee = modelBuilder.Entity<Employee>();
            //employee.HasKey(e => e.Id);
            //employee.Property(e => e.Id).ValueGeneratedOnAdd();
            employee.HasMany(e => e.JobHistory).WithOne().HasPrincipalKey(e => e.Id);
            employee.HasMany(e => e.Competencies).WithOne().HasPrincipalKey(e => e.Id);
            employee.HasMany(e => e.CourseResults).WithOne().HasPrincipalKey(e => e.Id);

            var employeeCompetency = modelBuilder.Entity<EmployeeCompetency>();
            //employeeCompetency.HasKey(ec => ec.Id);
            //employeeCompetency.Property(ec => ec.Id).ValueGeneratedOnAdd();
            employeeCompetency.HasOne(ec => ec.Competency).WithOne().HasPrincipalKey<Competency>(c => c.Id);

            var jobTitle = modelBuilder.Entity<JobTitle>();
            //jobTitle.HasKey(t => t.Id);
            //jobTitle.Property(t => t.Id).ValueGeneratedOnAdd();
            jobTitle.HasOne(t => t.Direction).WithMany().HasPrincipalKey(d => d.Id);
            jobTitle.HasMany(t => t.RequiredCompetency).WithOne().HasPrincipalKey(t => t.Id);

            var jobTitleCompetency = modelBuilder.Entity<JobTitleCompetency>();
            //jobTitleCompetency.HasKey(c => c.Id);
            //jobTitleCompetency.Property(c => c.Id).ValueGeneratedOnAdd();
            jobTitleCompetency.HasOne(c => c.Competency).WithOne().HasPrincipalKey<Competency>(c => c.Id);
        }
    }
}
