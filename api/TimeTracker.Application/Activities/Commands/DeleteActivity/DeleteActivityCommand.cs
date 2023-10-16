using MediatR;

namespace TimeTracker.Application.Activities.Commands.DeleteActivity
{
    public class DeleteActivityCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
