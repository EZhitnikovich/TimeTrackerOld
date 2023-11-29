using FluentValidation;

namespace TimeTracker.Application.Activities.Commands.UpdateActivity
{
    public class UpdateActivityCommandValidator : AbstractValidator<UpdateActivityCommand>
    {
        public UpdateActivityCommandValidator()
        {
            RuleFor(cmd => cmd.Id).NotEqual(Guid.Empty);
            RuleFor(cmd => cmd.Description).MaximumLength(250);
            RuleFor(cmd => cmd.StartInMilliseconds).GreaterThan(0);
            RuleFor(cmd => cmd.EndInMilliseconds)
                .GreaterThan(0)
                .GreaterThan(cmd => cmd.StartInMilliseconds);
            RuleFor(cmd => cmd.UserId).NotEqual(Guid.Empty);
        }
    }
}
