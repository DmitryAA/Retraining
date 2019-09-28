using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdVision.Retraining.Model {
    public class JobTitle {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public Direction Direction { get; set; }

        [Required]
        public bool IsObsolete { get; set; }


        public ICollection<JobTitleCompetency> RequiredCompetency { get; }

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
