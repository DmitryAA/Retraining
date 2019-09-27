using System;
namespace EdVision.Retraining.Model {
    public class JobTitleCompetency {
        public int Id { get; set; }
        public Competency Competency { get; set; }
        public double Level { get; set; }
        public double Weight { get; set; }
    }
}
