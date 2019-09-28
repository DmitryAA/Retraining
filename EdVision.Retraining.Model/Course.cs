using System;
using System.Collections.Generic;

namespace EdVision.Retraining.Model {
    public class Course {
        public int Id { get; set; }
        public string Name { get; set; }

        public Direction Direction { get; set; }

        public ICollection<EmployeeCompetency> RequiredCompetencies { get; set; }
        public ICollection<EmployeeCompetency> OutputCompetencies { get; set; }

        public Course() {
            RequiredCompetencies = new HashSet<EmployeeCompetency>();
            OutputCompetencies = new HashSet<EmployeeCompetency>();
        }
    }
}
