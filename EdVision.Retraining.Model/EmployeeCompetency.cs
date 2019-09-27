using System;
namespace EdVision.Retraining.Model {
    public static class CompetencyLevels {
        const double Epsilon = 0.0000001;

        public const double BOOL_NO = 0.0;
        public const double BOOL_YES = 1.0;

        public const double RANGE_NO_COMPETENCY = 0;
        public const double RANGE_KNOW_ABOUT = 0.33;
        public const double RANGE_KNOW_GOOD = 0.66;
        public const double RANGE_CAN_EXPLAIN = 1.0;

        public static bool IsBool(double value) {
            return Math.Abs(value - BOOL_NO) < Epsilon
                || Math.Abs(value - BOOL_YES) < Epsilon;
        }

        public static bool IsRange(double value) {
            return Math.Abs(value - RANGE_NO_COMPETENCY) < Epsilon
                || Math.Abs(value - RANGE_KNOW_ABOUT) < Epsilon
                || Math.Abs(value - RANGE_KNOW_GOOD) < Epsilon
                || Math.Abs(value - RANGE_CAN_EXPLAIN) < Epsilon;
        }
    }

    public class EmployeeCompetency {
        public int Id { get; private set; }
        public Competency Competency { get; private set; }
        public double Level { get; private set; }

        public EmployeeCompetency(Competency competency, double level) {
            Competency = competency;
            Func<double, bool> checker;
            switch (competency.Type) {
                case (CompetencyType.Bool):
                    checker = CompetencyLevels.IsBool;
                    break;
                case (CompetencyType.Range):
                    checker = CompetencyLevels.IsRange;
                    break;
                default:
                    throw new Exception("Cannot handle the type.");
            }
            if (!checker(level)) {
                throw new Exception("Cannot handle a level for the specified type.");
            }
            Level = level;
        }
    }
}
