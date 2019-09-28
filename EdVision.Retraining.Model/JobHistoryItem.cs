using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdVision.Retraining.Model {
    public class JobHistoryItem {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime ChangeDate { get; set; }
        [Required]
        public JobTitle Title { get; set; }
    }
}
