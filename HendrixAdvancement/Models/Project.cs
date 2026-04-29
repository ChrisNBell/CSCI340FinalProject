using System.ComponentModel.DataAnnotations;

namespace HendrixAdvancement.Models;

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
    public string? Priority { get; set; }
    public string? Status { get; set; }
    public decimal Cost { get; set; }
}