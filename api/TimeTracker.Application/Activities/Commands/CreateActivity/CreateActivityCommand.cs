using MediatR;

namespace TimeTracker.Application.Activities.Commands.CreateActivity
{
    public class CreateActivityCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public List<Guid>? TagIds { get; set; }
        public Guid? ProjectId { get; set; }
        public long StartInMilliseconds { get; set; }
        public long? EndInMilliseconds { get; set; }
    }
}
