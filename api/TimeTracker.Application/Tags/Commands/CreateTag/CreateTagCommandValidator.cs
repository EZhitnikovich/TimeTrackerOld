using FluentValidation;

namespace TimeTracker.Application.Tags.Commands.CreateTag
{
    public class CreateTagCommandValidator : AbstractValidator<CreateTagCommand>
    {
        public CreateTagCommandValidator()
        {
            RuleFor(cmd => cmd.Title).NotEmpty().MaximumLength(50);
        }
    }
}
