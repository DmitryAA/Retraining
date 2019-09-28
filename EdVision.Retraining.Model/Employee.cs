using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EdVision.Retraining.Model {
    public class Employee {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [Required]
        public double FiringProbability { get; set; }
        [Required]
        public double Efficency { get; set; }

        public ICollection<JobHistoryItem> JobHistory { get; }
        public ICollection<EmployeeCompetency> Competencies { get; }
        public ICollection<CoursePassingResult> CourseResults { get; }

        public Employee(string firstName, string middleName, string lastName): this() {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public Employee() {
            JobHistory = new HashSet<JobHistoryItem>();
            Competencies = new HashSet<EmployeeCompetency>();
            CourseResults = new HashSet<CoursePassingResult>();
        }

        //public void AddCompetency(Competency competency, double level) {
        //    Competencies.Add(new EmployeeCompetency(/*IdHelper.Instance.GetNextId<EmployeeCompetency>(), */competency, level));
        //}

        //public void PassCourse(Course course, int grade = 100) {
        //    if (course == null) {
        //        throw new ArgumentException("Must not be null", nameof(course));
        //    }
        //    if (0 > grade || grade > 100 ) {
        //        throw new ArgumentException("Most be in (0 - 100) range");
        //    }
        //    CourseResults.Add(new CoursePassingResult {
        //        Id = IdHelper.Instance.GetNextId<CoursePassingResult>(),
        //        Course = course,
        //        Grade = grade
        //    });
        //}

        //public ICollection<SoftSkill> SoftSkills { get; set; }
        //public JobTitle ActualJobTitle { get; set; }
        //public int YearsInCompany { get; set; }
        //public ICollection<string> Education { get; set; }
        //public ICollection<VolontierExperienceItem> VolonteerExperience { get; set; }
        //public ICollection<LaborDisciplineViolation> Violations { get; set; }
        //public ICollection<LaborBonus> LaborBonuses { get; set; }
    }
}
