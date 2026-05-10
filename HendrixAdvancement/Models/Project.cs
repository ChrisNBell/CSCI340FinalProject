using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HendrixAdvancement.Models
{

    public enum YesOrNo
    {
        Pending, Yes, No
    }

    public enum Categories
    {
        Space, Equipment, Program, Other
    }



    public class Project
    {
        public int ProjectId { get; set; }
        [Required]
        public required string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public required string Location { get; set; }
        [Required]
        public required string Department { get; set; }
        [Required]
        public required Categories Category { get; set; }
        [Required]
        public required string Timeframe { get; set; }

        [DataType(DataType.Currency)]
        public decimal Funded { get; set; }
        [DataType(DataType.Currency)]
        [Required]
        public decimal Cost { get; set; }
        public string? Image { get; set; }
        public YesOrNo Approval { get; set; }
        public required ICollection<Opportunity>? Opportunities { get; set; }
    }
}

