using System;
using System.Collections.Generic;

namespace EdVision.Retraining.Model {
    public class JobTitle {
        public int Id { get; set; }
        public string Name { get; set; }
        public Direction Direction { get; set; }

        public bool IsObsolete { get; set; }

        public ICollection<JobTitleCompetency> RequiredCompetency { get; set; }

        public JobTitle() {
            RequiredCompetency = new HashSet<JobTitleCompetency>();
        }
    }
}
