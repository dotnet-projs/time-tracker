namespace TimeTracker.API.Repositories;

public interface IProjectRepository
{
    
    Task<Project?> GetProjectById(int id);
    Task<List<Project>> GetAllProjects();
    Task<List<Project>> CreateProject(Project Project);
    Task<List<Project>> UpdateProject(int id, Project Project);
    Task<List<Project>?> DeleteProject(int id);
}