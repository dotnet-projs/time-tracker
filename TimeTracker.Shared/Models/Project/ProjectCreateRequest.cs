namespace TimeTracker.Shared.Models.Project;

// DTO for creating a project. Intentionally packs both Project and ProjectDetails fields into a single DTO,
// similar to ProjectResponse, to keep the API contract simple.
// No separate ProjectDetails DTO is used — Description, StartDate, and EndDate are meant for the ProjectDetails entity but are flattened here for convenience
public record struct ProjectCreateRequest(
    string Name,
    string? Description,
    DateTime? StartDate,
    DateTime? EndDate
);
