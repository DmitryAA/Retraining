using System;
namespace EdVision.Retraining.Model {
    public class CoursePassingResult {
        public int Id { get; set; }
        public Course Course { get; set; }
        public double Grade { get; set; }

        public CoursePassingResult(Course course, double grade) {
            Course = course;
            Grade = grade;
        }

        public CoursePassingResult() {

        }
    }
}
