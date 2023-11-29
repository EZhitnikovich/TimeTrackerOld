using MediatR;

namespace TimeTracker.Application.Activities.Commands.StartActivity
{
    public class StartActivityCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public List<Guid?>? TagIds { get; set; }
        public Guid? ProjectId { get; set; }
    }
}
