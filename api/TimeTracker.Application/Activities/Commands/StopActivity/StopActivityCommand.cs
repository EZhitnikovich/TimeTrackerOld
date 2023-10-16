using MediatR;

namespace TimeTracker.Application.Activities.Commands.StopActivity
{
    public class StopActivityCommand: IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
