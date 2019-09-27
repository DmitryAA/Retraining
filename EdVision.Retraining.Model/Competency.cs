using System;

namespace EdVision.Retraining.Model {
    public enum CompetencyType {
        Bool,
        Range
    }

    public class Competency {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public CompetencyType Type { get; private set; }

        public Competency(string name, CompetencyType type) {
            this.Name = name;
            this.Type = type;
        }
    }
}
