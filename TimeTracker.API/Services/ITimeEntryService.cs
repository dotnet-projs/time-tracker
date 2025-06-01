using TimeTracker.Shared.Models.Project;

namespace TimeTracker.API.Services;

public interface ITimeEntryService
{
    Task<TimeEntryResponse?> GetTimeEntryById(int id);
    Task<List<TimeEntryResponse>> GetAllTimeEntries();
    Task<List<TimeEntryResponse>> CreateTimeEntry(ProjectCreateRequest timeEntry);
    Task<List<TimeEntryResponse>?> UpdateTimeEntry(int id, ProjectUpdateRequest timeEntry);
    Task<List<TimeEntryResponse>?> DeleteTimeEntry(int id);
    Task<List<TimeEntryByProjectResponse>> GetTimeEntriesByProject(int projectId);

    // TimeEntryResponse? GetTimeEntryById(int id);
    // List<TimeEntryResponse> GetAllTimeEntries();
    // List<TimeEntryResponse> CreateTimeEntry(TimeEntryCreateRequest timeEntry);
    // List<TimeEntryResponse>? UpdateTimeEntry(int id, TimeEntryUpdateRequest timeEntry);
    // List<TimeEntryResponse>? DeleteTimeEntry(int id);
}