using System;

namespace EdVision.Retraining.Model {
    public enum CompetencyType {
        Bool,
        Range
    }

    public static class CompetencyLevels {
        const double Epsilon = 0.0000001;

        public const double BOOL_NO = 0.0;
        public const double BOOL_YES = 1.0;

        public const double RANGE_NO_COMPETENCY = 0;
        public const double RANGE_KNOW_ABOUT = 0.25;
        public const double RANGE_KNOW_GOOD = 0.5;
        public const double RANGE_KNOW_PERFECT = 0.75;
        public const double RANGE_CAN_EXPLAIN = 1.0;

        public static bool CheckValue(double value, CompetencyType type) {
            Func<double, bool> checker;
            switch (type) {
                case (CompetencyType.Bool):
                    checker = CompetencyLevels.IsBool;
                    break;
                case (CompetencyType.Range):
                    checker = CompetencyLevels.IsRange;
                    break;
                default:
                    return false;
            }
            return checker(value);
        }

        static bool IsBool(double value) {
            return Math.Abs(value - BOOL_NO) < Epsilon
                || Math.Abs(value - BOOL_YES) < Epsilon;
        }

        static bool IsRange(double value) {
            return Math.Abs(value - RANGE_NO_COMPETENCY) < Epsilon
                || Math.Abs(value - RANGE_KNOW_ABOUT) < Epsilon
                || Math.Abs(value - RANGE_KNOW_GOOD) < Epsilon
                || Math.Abs(value - RANGE_KNOW_PERFECT) < Epsilon
                || Math.Abs(value - RANGE_CAN_EXPLAIN) < Epsilon;
        }
    }

    public class Competency {
        public int Id { get; set; }
        public string Name { get; set; }
        public CompetencyType Type { get; set; }

        public Competency(string name, CompetencyType type) {
            this.Name = name;
            this.Type = type;
        }

        public Competency() {

        }

        public bool IsValid(double level) {
            return CompetencyLevels.CheckValue(level, Type);
        }
    }
}
