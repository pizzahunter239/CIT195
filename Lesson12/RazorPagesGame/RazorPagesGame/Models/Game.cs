﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesGame.Models
{
    public class Game
    {
        public int ID { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(30)]
        public string Genre { get; set; } = string.Empty;

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; } = string.Empty;

        // Foreign key for Studio
        public int? StudioID { get; set; }

        // Navigation property
        public Studio? Studio { get; set; }
    }
}