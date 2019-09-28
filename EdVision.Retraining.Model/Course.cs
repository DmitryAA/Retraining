using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdVision.Retraining.Model {
    public class Course {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public Direction Direction { get; set; }
        [Required]
        public double Price { get; set; }

        public ICollection<CourseInCompetency> RequiredCompetencies { get; set; }
        public ICollection<CourseOutCompetency> OutputCompetencies { get; set; }

        public Course(string name, Direction direction, double price) : this() {
            Name = name;
            Direction = direction;
            Price = price;
        }
        public Course() {
            Id = IdHelper.Instance.GetNextId<Course>();
            RequiredCompetencies = new HashSet<CourseInCompetency>();
            OutputCompetencies = new HashSet<CourseOutCompetency>();
        }
    }
}
