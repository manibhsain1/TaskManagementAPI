using Microsoft.EntityFrameworkCore;
using TaskManagement.Application;
using TaskManagement.Application.Interfaces;
using TaskManagement.Infrastructure.Data;

namespace TaskManagement.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _db;

    public TaskRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<TaskItem?> GetByIdAsync(int id)
    {
        return await _db.Tasks
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);

    }

    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        return await _db.Tasks
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(TaskItem task)
    {
        await _db.Tasks.AddAsync(task);
        await _db.SaveChangesAsync();
    }
    public async Task UpdateAsync(TaskItem task)
    {
        _db.Tasks.Update(task);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var task = await _db.Tasks.FindAsync(id);
        if (task is not null)
        {
            _db.Tasks.Remove(task);
            await _db.SaveChangesAsync();
        }

    }

}