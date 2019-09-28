using System;
using System.Collections.Generic;
using EdVision.Retraining.Model;

namespace EdVision.Retraining.API {
    public class EmployeProfessionRecommendation {
        public Employee Employee { get; }
        public List<PositionRecommendation> Recommendations { get; }

        public EmployeProfessionRecommendation(Employee employee, IEnumerable<PositionRecommendation> recommendations) {
            Employee = employee;
            Recommendations = new List<PositionRecommendation>(recommendations);
        }
    }

    public class PositionRecommendation {
        public JobTitle Position { get; }
        public List<Course> Courses { get; }

        public PositionRecommendation(JobTitle position, IEnumerable<Course> requiredCourses) {
            Position = position;
            Courses = new List<Course>(requiredCourses);
        }
    }
}
