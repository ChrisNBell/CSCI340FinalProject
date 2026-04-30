using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HendrixAdvancement.Models{
    public enum Priority
    {
        High, Medium, Low
    }

    public enum Status
    {
        Open, PartiallyFunded, Funded
    }

    public class Opportunity
    {    
        public int OpportunityId { get; set; }
        public int ProjectID { get; set; }
        public string? Title { get; set; }
        public Project? Project { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }
        public YesOrNo Nameable { get; set; }
    }
}
