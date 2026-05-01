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
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? Department { get; set; }
        public string? Category { get; set; }
        public string? Timeframe { get; set; }
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }
        public YesOrNo Approval { get; set; }
        public ICollection<Opportunity> Opportunities { get; set; }
    }
}

