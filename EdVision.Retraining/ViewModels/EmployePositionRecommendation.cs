using System;
using System.Collections.Generic;
using System.Linq;
using EdVision.Retraining.Model;

namespace EdVision.Retraining.API {
    public class EmployePositionRecommendation {
        public Employee Employee { get; }
        public List<PositionRecommendation> Recommendations { get; }

        public EmployePositionRecommendation(Employee employee, IEnumerable<PositionRecommendation> recommendations) {
            Employee = employee;
            Recommendations = new List<PositionRecommendation>(recommendations);
        }
    }

    public class PositionRecommendation {
        public JobTitle Position { get; }
        public List<Course> Courses { get; }
        public double TotalPrice { get; }

        public PositionRecommendation(JobTitle position, IEnumerable<Course> requiredCourses) {
            Position = position;
            Courses = new List<Course>(requiredCourses);
            TotalPrice = requiredCourses.Aggregate(0.0, (l, r) => l + r.Price);
        }
    }
}
