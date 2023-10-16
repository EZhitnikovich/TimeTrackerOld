using FluentValidation;

namespace TimeTracker.Application.Activities.Commands.DeleteActivity
{
    public class DeleteActivityCommandValidator : AbstractValidator<DeleteActivityCommand>
    {
        public DeleteActivityCommandValidator()
        {
            RuleFor(cmd => cmd.UserId).NotEqual(Guid.Empty);
        }
    }
}
