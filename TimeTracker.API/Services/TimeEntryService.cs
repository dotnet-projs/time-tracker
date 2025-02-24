using Mapster;

namespace TimeTracker.API.Services;

public class TimeEntryService : ITimeEntryService
{
    private readonly ITimeEntryRepository _timeEntryRepo;

    public TimeEntryService(ITimeEntryRepository timeEntryRepo)
    {
        _timeEntryRepo = timeEntryRepo;
    }

    public async Task<List<TimeEntryResponse>> GetAllTimeEntries()
    {
        var result = await _timeEntryRepo.GetAllTimeEntries();
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
    
    public async Task<TimeEntryResponse?> GetTimeEntryById(int id)
    {
        var result = await _timeEntryRepo.GetTimeEntryById(id);
        if (result is null)
        {
            return null;
        }
        return result.Adapt<TimeEntryResponse>();
    }

    public async Task<List<TimeEntryResponse>> CreateTimeEntry(TimeEntryCreateRequest request)
    {
        var newEntry = request.Adapt<TimeEntry>();
        var result = await _timeEntryRepo.CreateTimeEntry(newEntry);
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

    public async Task<List<TimeEntryResponse>?> UpdateTimeEntry(int id, TimeEntryUpdateRequest request)
    {
        try
        {
            var updateEntry = request.Adapt<TimeEntry>();
            var result = await _timeEntryRepo.UpdateTimeEntry(id, updateEntry);
            return result.Adapt<List<TimeEntryResponse>>();
        }
        catch (EntityNotFoundException)
        {
            return null;
        }

        // if (result is null)
        //  {
        //  return null;
        //  }
    }

    public async Task<List<TimeEntryResponse>?> DeleteTimeEntry(int id)
    {
        var result = await _timeEntryRepo.DeleteTimeEntry(id);
        if (result is null)
        {
            return null;
        }

        return result.Adapt<List<TimeEntryResponse>>();
    }
}