﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdVision.Retraining.Model {
    public class Direction {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Direction(string name) {
            this.Name = name;
        }

        public Direction() {

        }
    }
}
