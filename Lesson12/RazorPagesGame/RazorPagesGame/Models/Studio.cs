using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesGame.Models
{
    public class Studio
    {
        public int ID { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Founded Date")]
        [DataType(DataType.Date)]
        public DateTime FoundedDate { get; set; }

        [StringLength(200)]
        public string Headquarters { get; set; } = string.Empty;

        // Navigation property
        public List<Game> Games { get; set; } = new List<Game>();
    }
}
