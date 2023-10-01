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
        public Project? Project { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
