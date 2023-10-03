using FluentValidation;

namespace TimeTracker.Application.Activities.Commands.CreateActivity
{
    public class CreateActivityCommandValidator: AbstractValidator<CreateActivityCommand>
    {
        public CreateActivityCommandValidator()
        {
            RuleFor(cmd => cmd.Description).MaximumLength(250);
            RuleFor(cmd => cmd.StartInMilliseconds).GreaterThan(0);
            RuleFor(cmd => cmd.EndInMilliseconds)
                .NotNull()
                .GreaterThan(0)
                .GreaterThan(cmd => cmd.StartInMilliseconds);
        }
    }
}
