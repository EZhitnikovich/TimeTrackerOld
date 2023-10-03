using MediatR;

namespace TimeTracker.Application.Activities.Commands.StartActivity
{
    public class StartActivityCommand: IRequest<Guid>
    { // TODO: add user id
        public string Description { get; set; }
        public List<Guid> TagIds { get; set; }
        public Guid? ProjectId { get; set; }
    }
}
