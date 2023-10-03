using FluentValidation;

namespace TimeTracker.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandValidator: AbstractValidator<DeleteProjectCommand>
    {
        public DeleteProjectCommandValidator()
        {
            RuleFor(cmd => cmd.Id).NotEqual(Guid.Empty);
        }
    }
}
