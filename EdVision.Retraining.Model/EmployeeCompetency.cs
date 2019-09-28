using System;
namespace EdVision.Retraining.Model {
    public class EmployeeCompetency {
        public int Id { get; set; }
        public Competency Competency { get; set; }
        public double Level { get; set; }

        public EmployeeCompetency(Competency competency, double level) {
            Competency = competency;
            if (Competency.IsValid(level)) {
                Level = level;
            } else {
                throw new ArgumentException("Cannot match the specified 'level' with the specified 'competency'.");
            }
        }

        public EmployeeCompetency() {
            
        }
    }
}
