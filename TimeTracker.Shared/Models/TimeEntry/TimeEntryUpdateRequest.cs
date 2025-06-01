namespace TimeTracker.Shared.Models.TimeEntry;

public record struct TimeEntryRequest(int ProjectId, DateTime Start, DateTime? End);