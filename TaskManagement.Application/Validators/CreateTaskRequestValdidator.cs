using FluentValidation;
using TaskManagement.Application;
using TaskManagement.Application.DTOs;


namespace TaskManagement.Application.Validator;


public class CreateTaskRequestValidator : AbstractValidator<CreateTaskRequest>
{
    public CreateTaskRequestValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required").MaximumLength(200).WithMessage("Title cannot be more than 200 characters");

        RuleFor(x => x.DueDate).GreaterThan(DateTime.UtcNow).WithMessage("Due Date must be in the future");

        RuleFor(x => x.UserId).GreaterThan(0).WithMessage("A valid user must be assigned here");

    }

}