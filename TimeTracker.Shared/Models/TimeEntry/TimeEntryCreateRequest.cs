namespace TimeTracker.Shared.Models.TimeEntry;

// create DTO
public record struct TimeEntryCreateRequest(string Project, DateTime Start, DateTime? End);