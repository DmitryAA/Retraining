using System;
namespace EdVision.Retraining.Model {
    public enum JobTitleChangeType {
        Promotion,
        Transfer,
        Downgrade

    }

    public class JobTitleChangeHistoryItem {
        public JobTitle JobTitle { get; set; }
        public DateTime DateTime { get; set; }
        public JobTitleChangeType ChangeType { get; set; }
    }
}
