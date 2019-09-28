using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdVision.Retraining.Model {
    public class CoursePassingResult {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Course Course { get; set; }
        [Required]
        public double Grade { get; set; }

        public CoursePassingResult(Course course, double grade) {
            Course = course;
            Grade = grade;
        }

        public CoursePassingResult() {

        }
    }
}
