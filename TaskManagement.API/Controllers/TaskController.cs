using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Interfaces;

namespace TaskManagement.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskservice;

    public TaskController(ITaskService taskservice)
    {
        _taskservice = taskservice;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _taskservice.GetAllTaskAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _taskservice.GetTaskByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest request)
    {
        var result = await _taskservice.CreateTaskAsync(request);

        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);

    }

    [HttpPatch("{id}/complete")]
    public async Task Complete(int id)
    {
        await _taskservice.CompleteTaskAsync(id);

    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _taskservice.DeleteTaskAsync(id);
      
    }






}