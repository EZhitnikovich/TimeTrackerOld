using MediatR;

namespace TimeTracker.Application.Activities.Commands.StopActivity
{
    public class StopActivityCommand: IRequest
    {
        public Guid Id { get; set; }
    }
}
