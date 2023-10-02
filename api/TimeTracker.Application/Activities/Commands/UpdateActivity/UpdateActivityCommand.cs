using MediatR;
using TimeTracker.Domain;

namespace TimeTracker.Application.Activities.Commands.UpdateActivity
{
    public class UpdateActivityCommand: IRequest
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int StartInMilliseconds { get; set; }
        public int EndInMilliseconds { get; set;}
        public Guid? ProjectId { get; set; }
        public List<Guid> TagIds { get; set; }
    }
}
