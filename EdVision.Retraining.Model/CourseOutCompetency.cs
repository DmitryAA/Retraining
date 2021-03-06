﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdVision.Retraining.Model {
    public class CourseOutCompetency {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Competency Competency { get; set; }

        [Required]
        public double Level { get; set; }

        public CourseOutCompetency(Competency competency, double level) {
            //Id = IdHelper.Instance.GetNextId<CourseOutCompetency>();
            Competency = competency;
            if (Competency.IsValid(level)) {
                Level = level;
            } else {
                throw new ArgumentException("Cannot match the specified 'level' with the specified 'competency'.");
            }
        }

        public CourseOutCompetency() { }

        public override string ToString() {
            return $"{{id: {Id}, competency: {{ name: {Competency.Name}; type: {Competency.Type}}}; level: {Level}}}";
        }
    }
}
