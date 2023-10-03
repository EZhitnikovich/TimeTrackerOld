using FluentValidation;

namespace TimeTracker.Application.Activities.Commands.DeleteActivity
{
    public class DeleteActivityCommandValidator : AbstractValidator<DeleteActivityCommand>
    {
        public DeleteActivityCommandValidator()
        { // TODO: add user id validation
        }
    }
}
