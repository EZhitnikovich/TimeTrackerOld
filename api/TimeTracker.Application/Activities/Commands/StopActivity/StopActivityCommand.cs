using MediatR;

namespace TimeTracker.Application.Activities.Commands.StopActivity
{
    public class StopActivityCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
