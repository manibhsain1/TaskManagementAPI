using TaskManagement.Application;
namespace TaskManagement.Application.DTOs;

public class TaskDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime DueDate { get; set; }

    public string Status { get; set; } = "Pending";


    public DateTime CreatedAt { get; set; }



    public static TaskDto From(TaskItem task) => new()
    {
        Id = task.Id,
        Title = task.Title,
        Description = task.Description,
        DueDate = task.DueDate,
        Status = task.Status,
        CreatedAt = task.CreatedAt

    };





}