namespace TaskManagement.Application;


public class TaskItem
{


    public int UserId { get; private set; }      // ← add this
    public User? User { get; private set; }

    public int Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public DateTime DueDate { get; private set; }
    public string Status { get; private set; } = "Pending";
    public DateTime CreatedAt { get; private set; }

    private TaskItem() { }

    public TaskItem(string title, string? description, DateTime duedate)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty", nameof(title));

        Title = title;
        Description = description;
        DueDate = duedate;
        CreatedAt = DateTime.UtcNow;

    }
    public void Complete()
    {
        if (Status == "Completed")
            throw new InvalidOperationException("Task is already Complete");

        Status = "Completed";
    }

    public void UpdateDetails(string title, string? description, DateTime duedate)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty", nameof(title));

        Title = title;
        Description = description;
        DueDate = duedate;

    }

}
