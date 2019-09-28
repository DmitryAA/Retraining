using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdVision.Retraining.Model {
    public class JobTitleCompetency {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Competency Competency { get; set; }

        [Required]
        public double Level { get; set; }

        [Required]
        public double Weight { get; set; }

        public JobTitleCompetency(Competency competency, double level, double weight) {
            //Id = IdHelper.Instance.GetNextId<JobTitleCompetency>();
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
