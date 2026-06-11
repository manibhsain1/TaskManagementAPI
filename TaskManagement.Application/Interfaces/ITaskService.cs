using TaskManagement.Application.DTOs;


namespace TaskManagement.Application.Interfaces;

public interface ITaskService
{
    Task<TaskDto> CreateTaskAsync(CreateTaskRequest request);

    Task<TaskDto> GetTaskByIdAsync(int id);

    Task<IEnumerable<TaskDto>> GetAllTaskAsync();

    Task CompleteTaskAsync(int id);

    Task DeleteTaskAsync(int id);

}
