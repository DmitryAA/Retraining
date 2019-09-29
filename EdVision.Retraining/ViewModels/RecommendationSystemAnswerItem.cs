using System.Collections.Generic;

namespace EdVision.Retraining.API {
    public class RecommendationSystemAnswerItem {
        public int EmployeeId { get; set; }
        public int PositionId { get; set; }
        public double Distance { get; set; }
        public List<int> CourseIds { get; set; }

        public RecommendationSystemAnswerItem(int positionId, IEnumerable<int> courseIds) {
            PositionId = positionId;
            CourseIds = new List<int>(courseIds);
        }

        public RecommendationSystemAnswerItem() {
            CourseIds = new List<int>();
        }
    }
}
