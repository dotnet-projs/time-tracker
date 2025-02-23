using Mapster;
using TimeTracker.API.Repositories;
using TimeTracker.Shared.Entities;
using TimeTracker.Shared.Models.TimeEntry;

namespace TimeTracker.API.Services;

public class TimeEntryService : ITimeEntryService
{
    private readonly ITimeEntryRepository _timeEntryRepo;

    public TimeEntryService(ITimeEntryRepository timeEntryRepo)
    {
        _timeEntryRepo = timeEntryRepo;
    }

    public List<TimeEntryResponse> GetAllTimeEntries()
    {
        var result = _timeEntryRepo.GetAllTimeEntries();
        return result.Adapt<List<TimeEntryResponse>>();
        // manual mapping
        // return result.Select(t => new TimeEntryResponse
        // {
        //     Id = t.Id,
        //     Project = t.Project,
        //     Start = t.Start, 
        //     End = t.End
        // }).ToList();
    }
    
    public TimeEntryResponse? GetTimeEntryById(int id)
    {
        var result = _timeEntryRepo.GetTimeEntryById(id);
        if (result is null)
        {
            return null;
        }
        return result.Adapt<TimeEntryResponse>();
    }

    public List<TimeEntryResponse> CreateTimeEntry(TimeEntryCreateRequest request)
    {
        var newEntry = request.Adapt<TimeEntry>();
        var result = _timeEntryRepo.CreateTimeEntry(newEntry);
        return result.Adapt<List<TimeEntryResponse>>();
        // manual mapping
        // var newEntry = new TimeEntry
        // {
        //     Project = timeEntry.Project,
        //     Start = timeEntry.Start,
        //     End = timeEntry.End
        // };
        // var result = _timeEntryRepo.CreateTimeEntry(newEntry);
        // return result.Select(t => new TimeEntryResponse
        // {
        //     Id = t.Id,
        //     Project = t.Project,
        //     Start = t.Start, 
        //     End = t.End
        // }).ToList();
    }

    public List<TimeEntryResponse>? UpdateTimeEntry(int id, TimeEntryUpdateRequest request)
    {
        var updateEntry = request.Adapt<TimeEntry>();
        var result = _timeEntryRepo.UpdateTimeEntry(id, updateEntry);
        if (result is null)
        {
            return null;
        }
        return result.Adapt<List<TimeEntryResponse>>();
    }

    public List<TimeEntryResponse>? DeleteTimeEntry(int id)
    {
        var result = _timeEntryRepo.DeleteTimeEntry(id);
        if (result is null)
        {
            return null;
        }

        return result.Adapt<List<TimeEntryResponse>>();
    }
}