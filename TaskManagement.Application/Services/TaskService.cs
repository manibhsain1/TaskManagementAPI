using TaskManagement.Application.DTOs;
using TaskManagement.Application.Exceptions;
using TaskManagement.Application.Interfaces;

namespace TaskManagement.Application.Services;


public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;

    public TaskService(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<TaskDto> CreateTaskAsync(CreateTaskRequest request)
    {
        var item = new TaskItem(request.Title, request.Description, request.DueDate);
        await _repository.AddAsync(item);
        return TaskDto.From(item);

    }
    public async Task<TaskDto> GetTaskByIdAsync(int id)
    {
        var task = await _repository.GetByIdAsync(id);
        if (task is null)
            throw new NotFoundException(nameof(TaskItem), id);

        return TaskDto.From(task);
    }

    public async Task CompleteTaskAsync(int id)
    {
        var task = await _repository.GetByIdAsync(id);
        if (task is null)
            throw new NotFoundException(nameof(TaskItem), id);

        task.Complete();

        await _repository.UpdateAsync(task);


    }
    public async Task<IEnumerable<TaskDto>> GetAllTaskAsync()
    {
        var tasks = await _repository.GetAllAsync();

        return tasks.Select(TaskDto.From);

    }

    public async Task DeleteTaskAsync(int id)
    {
        var task = await _repository.GetByIdAsync(id);
        if (task is null)
            throw new NotFoundException(nameof(TaskItem), id);
        await _repository.DeleteAsync(id);
    }

}

