using FluentValidation;

namespace TimeTracker.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandValidator: AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(cmd => cmd.Id).NotEqual(Guid.Empty);
            RuleFor(cmd => cmd.Title).NotEmpty().MaximumLength(100);
        }
    }
}
