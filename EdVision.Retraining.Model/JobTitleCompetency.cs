using System;

namespace EdVision.Retraining.Model {
    public class JobTitleCompetency {
        public int Id { get; set; }
        public Competency Competency { get; set; }
        public double Level { get; set; }
        public double Weight { get; set; }

        public JobTitleCompetency(Competency competency, double level, double weight) {
            Id = IdHelper.Instance.GetNextId<JobTitleCompetency>();
            Competency = competency;
            if (Competency.IsValid(level)) {
                Level = level;
            } else {
                throw new ArgumentException("Cannot match the specified 'level' with the specified 'competency'.");
            }
            Weight = weight;
        }

        public JobTitleCompetency() {

        }
    }
}
