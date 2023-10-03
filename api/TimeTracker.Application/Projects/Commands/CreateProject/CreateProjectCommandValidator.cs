using FluentValidation;

namespace TimeTracker.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommandValidator: AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(cmd => cmd.Title).NotEmpty().MaximumLength(100);
        }
    }
}
