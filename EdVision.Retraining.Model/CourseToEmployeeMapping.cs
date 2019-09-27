using System;
namespace EdVision.Retraining.Model {
    public class CourseToEmployeeMapping {
        public Employee Employee { get; set; }
        public Course Course { get; set; }

        public int Grade { get; set; }
    }
}
