using System;
using System.Collections.Generic;

namespace EdVision.Retraining.Model {
    public class Course {
        public int Id { get; set; }
        public string Name { get; set; }

        public Direction Direction { get; set; }
        public double Price { get; set; }

        public ICollection<EmployeeCompetency> RequiredCompetencies { get; set; }
        public ICollection<EmployeeCompetency> OutputCompetencies { get; set; }

        public Course(string name, Direction direction, double price) : this() {
            Name = name;
            Direction = direction;
            Price = price;
        }
        public Course() {
            RequiredCompetencies = new HashSet<EmployeeCompetency>();
            OutputCompetencies = new HashSet<EmployeeCompetency>();
        }
    }
}
