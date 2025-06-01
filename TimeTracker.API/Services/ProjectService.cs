using Mapster;
using TimeTracker.Shared.Models.Project;

namespace TimeTracker.API.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepo;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepo = projectRepository;
    }

    public async Task<List<ProjectResponse>> GetAllProjects()
    {
        var result = await _projectRepo.GetAllProjects();
        return result.Adapt<List<ProjectResponse>>();
    } 

    public async Task<ProjectResponse?> GetProjectById(int id)
    {
        var result = await _projectRepo.GetProjectById(id);
        if (result is null)
        {
            return null;
        }
        return result.Adapt<ProjectResponse>();
    }
    
    public async Task<List<ProjectResponse>> CreateProject(ProjectCreateRequest request)
    {
        var newEntry = request.Adapt<Project>(); // maps only Name to the Project object (since that’s the only relevant field)
        newEntry.ProjectDetails = request.Adapt<ProjectDetails>(); // maps Description, StartDate, EndDate into a new ProjectDetails object

        var result = await _projectRepo.CreateProject(newEntry);
        return result.Adapt<List<ProjectResponse>>();
    }
    
    public async Task<List<ProjectResponse>?> UpdateProject(int id, ProjectUpdateRequest request)
    {
        try
        {
            var updateEntry = request.Adapt<Project>();
            updateEntry.ProjectDetails = request.Adapt<ProjectDetails>();

            var result = await _projectRepo.UpdateProject(id, updateEntry);
            return result.Adapt<List<ProjectResponse>>();
        }
        catch (EntityNotFoundException)
        {
            return null;
        }
    }
    
    public async Task<List<ProjectResponse>?> DeleteProject(int id)
    {
        var result = await _projectRepo.DeleteProject(id);
        if (result is null)
        {
            return null;
        }

        return result.Adapt<List<ProjectResponse>>();
    }
} 