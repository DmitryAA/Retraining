using EdVision.Retraining.Model;
using Microsoft.EntityFrameworkCore;

namespace EdVision.Retraining.DataLayer {
    public class RetrainingContext: DbContext {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Competency> Competencies { get; set; }

        RetrainingContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            var competency = modelBuilder.Entity<Competency>();
            competency.HasKey(c => c.Id);

            var course = modelBuilder.Entity<Course>();
            course.HasKey(c => c.Id);
            course.HasOne(c => c.Direction).WithOne().HasPrincipalKey<Direction>(d => d.Id);
            course.HasMany(c => c.RequiredCompetencies).WithOne().HasPrincipalKey(c => c.Id);
            course.HasMany(c => c.OutputCompetencies).WithOne().HasPrincipalKey(c => c.Id);

            var courseToEmployeeMapping = modelBuilder.Entity<CourseToEmployeeMapping>();
            courseToEmployeeMapping.HasOne(m => m.Course).WithOne().HasPrincipalKey<Course>(c => c.Id);

            var direction = modelBuilder.Entity<Direction>();
            direction.HasKey(d => d.Id);

            var employee = modelBuilder.Entity<Employee>();
            employee.HasKey(e => e.Id);
            employee.HasOne(e => e.JobTitle).WithMany().HasPrincipalKey(t => t.Id);
            employee.HasMany(e => e.Competencies).WithOne().HasPrincipalKey(e => e.Id);
            employee.HasMany(e => e._CourseToEmployees).WithOne(m => m.Employee).IsRequired(true);

            var employeeCompetency = modelBuilder.Entity<EmployeeCompetency>();
            employeeCompetency.HasKey(ec => ec.Id);
            employeeCompetency.HasOne(ec => ec.Competency).WithOne().HasPrincipalKey<Competency>(c => c.Id);

            var jobTitle = modelBuilder.Entity<JobTitle>();
            jobTitle.HasKey(t => t.Id);
            jobTitle.HasOne(t => t.Direction).WithMany().HasPrincipalKey(d => d.Id);
            jobTitle.HasMany(t => t.RequiredCompetency).WithOne().HasPrincipalKey(t => t.Id);

            var jobTitleCompetency = modelBuilder.Entity<JobTitleCompetency>();
            jobTitleCompetency.HasKey(c => c.Id);
            jobTitleCompetency.HasOne(c => c.Competency).WithOne().HasPrincipalKey<Competency>(c => c.Id);
        }
    }
}
