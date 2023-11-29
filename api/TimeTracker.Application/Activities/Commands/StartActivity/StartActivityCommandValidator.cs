using FluentValidation;

namespace TimeTracker.Application.Activities.Commands.StartActivity
{
    public class StartActivityCommandValidator : AbstractValidator<StartActivityCommand>
    {
        public StartActivityCommandValidator()
        {
            RuleFor(cmd => cmd.Description).MaximumLength(250);
            RuleFor(cmd => cmd.UserId).NotEqual(Guid.Empty);
        }
    }
}
