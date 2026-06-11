# Task Management API

A RESTful API built with ASP.NET Core demonstrating three-layer architecture, dependency injection, and production-grade patterns.

## Architecture

The solution is split into three projects:

- **TaskManagement.API** — HTTP layer. Controllers, middleware. No business logic.
- **TaskManagement.Application** — Business logic layer. Services, interfaces, DTOs, validators, domain entities. No framework dependencies.
- **TaskManagement.Infrastructure** — Data access layer. EF Core, SQLite, repositories.

Dependency direction: API → Application ← Infrastructure. Application has zero knowledge of EF Core or ASP.NET Core.

## Patterns Used

- **Dependency Injection** — all dependencies injected through interfaces, never newed up inside classes
- **Repository Pattern** — `ITaskRepository` defined in Application, implemented in Infrastructure. Business logic never touches EF Core directly.
- **Domain Entity with Encapsulation** — `TaskItem` has private setters and behaviour methods (`Complete()`, `UpdateDetails()`). Invalid state is impossible by construction.
- **DTOs** — `CreateTaskRequest` for incoming data, `TaskDto` for outgoing data. Domain entities never exposed directly to callers.
- **FluentValidation** — validation rules in a dedicated validator class, not scattered across controllers or services
- **Global Exception Handling** — single middleware catches all exceptions and maps them to correct HTTP status codes. Stack traces never leak to clients.

## Endpoints

| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/tasks` | Get all tasks |
| GET | `/api/tasks/{id}` | Get task by id |
| POST | `/api/tasks` | Create a task |
| PATCH | `/api/tasks/{id}/complete` | Mark task as complete |
| DELETE | `/api/tasks/{id}` | Delete a task |

## Running Locally

```bash
dotnet run --project TaskManagement.API
```

Navigate to `https://localhost:{port}/swagger` to explore the API.

Database is SQLite — `tasks.db` file created automatically on first run. Migrations applied on startup.

## Tech Stack

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core with SQLite
- FluentValidation
- Swashbuckle (Swagger)
