namespace TimeTracker.Shared.Models.TimeEntry;

// create DTO
public class TimeEntryCreateRequest
{
    public required string Project { get; set; }
    public DateTime Start { get; set; } = DateTime.Now;
    public DateTime? End { get; set; }
}