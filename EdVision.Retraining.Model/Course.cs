using System;
using System.Collections.Generic;

namespace EdVision.Retraining.Model {
    public class Course {
        public int Id { get; set; }
        public string Name { get; set; }

        public Direction Direction { get; set; }

        public IReadOnlyList<EmployeeCompetency> RequiredCompetencies { get; set; }
        public IReadOnlyList<EmployeeCompetency> OutputCompetencies { get; set; }
    }
}
