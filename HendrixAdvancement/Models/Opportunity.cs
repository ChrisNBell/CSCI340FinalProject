using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HendrixAdvancement.Models{
    public enum Priority
    {
        High, Medium, Low
    }

    public enum Status
    {
        Open, 
        [Display(Name = "Partialy Funded")]
        PartiallyFunded, 
        Funded
    }

    public class Opportunity
    {    
        public int OpportunityId { get; set; }
        public int ProjectID { get; set; }
        [Required]
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required Project Project { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Funded { get; set; }
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }
        public string? Image { get; set; }
        public YesOrNo Nameable { get; set; }
    }
}
