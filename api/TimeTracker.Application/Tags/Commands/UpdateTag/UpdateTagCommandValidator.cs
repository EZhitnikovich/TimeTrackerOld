using FluentValidation;

namespace TimeTracker.Application.Tags.Commands.UpdateTag
{
    public class UpdateTagCommandValidator : AbstractValidator<UpdateTagCommand>
    {
        public UpdateTagCommandValidator()
        {
            RuleFor(cmd=>cmd.Id).NotEqual(Guid.Empty);
            RuleFor(cmd => cmd.Title).NotEmpty().MaximumLength(50);
            RuleFor(cmd => cmd.UserId).NotEqual(Guid.Empty);
        }
    }
}
