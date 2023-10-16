using FluentValidation;

namespace TimeTracker.Application.Activities.Commands.StopActivity
{
    public class StopActivityCommandValidator : AbstractValidator<StopActivityCommand>
    {
        public StopActivityCommandValidator()
        {
            RuleFor(cmd => cmd.Id).NotEqual(Guid.Empty);
            RuleFor(cmd => cmd.UserId).NotEqual(Guid.Empty);
        }
    }
}
