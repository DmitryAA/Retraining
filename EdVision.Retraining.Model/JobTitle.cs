using System.Collections.Generic;

namespace EdVision.Retraining.Model {
    public class JobTitle {
        public int Id { get; set; }
        public string Name { get; set; }
        public Direction Direction { get; set; }

        public bool IsObsolete { get; set; }

        public ICollection<JobTitleCompetency> RequiredCompetency { get; set; }

        public JobTitle(string name, Direction direction): this() {
            Name = name;
            Direction = direction;
        }

        public JobTitle() {
            RequiredCompetency = new HashSet<JobTitleCompetency>();
        }

        public void AddRequiredCompetency(Competency competency, double level, double weight) {
            RequiredCompetency.Add(new JobTitleCompetency(competency, level, weight));
        }
    }
}
