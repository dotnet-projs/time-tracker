namespace TimeTracker.Shared.Models.TimeEntry;

// create DTO
public record struct TimeEntryCreateRequest(int ProjectId, DateTime Start, DateTime? End);