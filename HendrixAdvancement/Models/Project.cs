using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HendrixAdvancement.Models{

    public enum YesOrNo
    {
        Pending, Yes, No
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
        public required string Category { get; set; }
        [Required]
        public required string Timeframe { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }
        public YesOrNo Approval { get; set; }
        public ICollection<Opportunity>? Opportunities { get; set; }
    }
}

