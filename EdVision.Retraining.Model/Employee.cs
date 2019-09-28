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
        public DateTime DateOfBirth { get; set; }

        [Required]
        public double FiringProbability { get; set; }
        [Required]
        public double Efficency { get; set; }
        [Required]
        public double Loyality { get; set; }

        // TODO: Useful fields for HRs.
        //public ICollection<string> UsedBonuses { get; } // Sport, Eng courses, etc.
        //public ICollection<string> Hobbies { get; }

        public ICollection<JobHistoryItem> JobHistory { get; }
        public ICollection<EmployeeCompetency> Competencies { get; }
        public ICollection<CoursePassingResult> CourseResults { get; }

        public Employee(string firstName, string middleName, string lastName, DateTime dateOfBirth, double firingProbability, double efficency, double loyality): this() {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            FiringProbability = firingProbability;
            Efficency = efficency;
            Loyality = loyality;
        }

        public Employee() {
            JobHistory = new HashSet<JobHistoryItem>();
            Competencies = new HashSet<EmployeeCompetency>();
            CourseResults = new HashSet<CoursePassingResult>();
        }
    }
}
