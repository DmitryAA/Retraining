﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace EdVision.Retraining.Model {
    public class Employee {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public double FiringProbability { get; set; }
        public double Efficency { get; set; }

        public JobTitle JobTitle { get; set; }

        public ICollection<EmployeeCompetency> Competencies { get; set; }
        public ICollection<Course> FinishedCources => CourseResults.Select(m => m.Course).ToList();

        public ICollection<CoursePassingResult> CourseResults { get; set; }

        public Employee(string firstName, string middleName, string lastName): this() {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public Employee() {
            Competencies = new HashSet<EmployeeCompetency>();
            CourseResults = new HashSet<CoursePassingResult>();
        }

        public void AddCompetency(Competency competency, double level) {
            Competencies.Add(new EmployeeCompetency(/*IdHelper.Instance.GetNextId<EmployeeCompetency>(), */competency, level));
        }

        public void PassCourse(Course course, int grade = 100) {
            if (course == null) {
                throw new ArgumentException("Must not be null", nameof(course));
            }
            if (0 > grade || grade > 100 ) {
                throw new ArgumentException("Most be in (0 - 100) range");
            }
            CourseResults.Add(new CoursePassingResult {
                Id = IdHelper.Instance.GetNextId<CoursePassingResult>(),
                Course = course,
                Grade = grade
            });
        }

        //public ICollection<SoftSkill> SoftSkills { get; set; }
        //public JobTitle ActualJobTitle { get; set; }
        //public int YearsInCompany { get; set; }
        //public ICollection<string> Education { get; set; }
        //public ICollection<VolontierExperienceItem> VolonteerExperience { get; set; }
        //public ICollection<LaborDisciplineViolation> Violations { get; set; }
        //public ICollection<LaborBonus> LaborBonuses { get; set; }
    }
}
