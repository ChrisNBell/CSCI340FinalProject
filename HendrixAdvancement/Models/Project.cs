using System.ComponentModel.DataAnnotations;

namespace HendrixAdvancement.Models;

public enum Priority
{
    High, Medium, Low
}

public enum Status
{
    Open, PartiallyFunded, Funded
}

public enum YesOrNo
{
    Yes, No
}

public class Project
{
    public int Id { get; set; }
    public string? Title { get; set; }
    [DataType(DataType.Date)]
    public string? Description { get; set; }
    public string? Location { get; set; }
    public string? Department { get; set; }
    public string? Category { get; set; }
    public string? Timeframe { get; set; }
    public Priority Priority { get; set; }
    public Status Status { get; set; }
    public decimal Cost { get; set; }
    public YesOrNo Nameable { get; set; }
}