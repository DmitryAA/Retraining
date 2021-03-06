﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;

namespace EdVision.Retraining.Model {
    public class JobTitleRecommendation {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }
        public Employee Employee { get; set; }
        public JobTitle JobTitle { get; set; }
        [Required]
        public double Distance { get; set; }
        public IReadOnlyList<Course> CoursesToLearn => _CourseToJobTitleRecommendationMappings.Select(m => m.Course).ToList();

        [JsonIgnore]
        public List<CourseToJobTitleRecommendationMapping> _CourseToJobTitleRecommendationMappings { get; }

        public JobTitleRecommendation(Employee employee, JobTitle jobTitle, double distance, IEnumerable<Course> courses) {
            Employee = employee;
            Distance = distance;
            JobTitle = jobTitle;
            TimeStamp = DateTime.Now;
            _CourseToJobTitleRecommendationMappings = courses.Select(c =>
                new CourseToJobTitleRecommendationMapping {
                    Course = c
                }).ToList();
        }

        public JobTitleRecommendation() {
            _CourseToJobTitleRecommendationMappings = new List<CourseToJobTitleRecommendationMapping>();
        }
    }
}
