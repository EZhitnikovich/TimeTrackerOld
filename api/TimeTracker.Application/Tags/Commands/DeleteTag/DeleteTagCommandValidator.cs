using FluentValidation;

namespace TimeTracker.Application.Tags.Commands.DeleteTag
{
    public class DeleteTagCommandValidator: AbstractValidator<DeleteTagCommand>
    {
        public DeleteTagCommandValidator()
        {
            RuleFor(cmd => cmd.Id).NotEqual(Guid.Empty);
            RuleFor(cmd => cmd.UserId).NotEqual(Guid.Empty);
        }
    }
}
