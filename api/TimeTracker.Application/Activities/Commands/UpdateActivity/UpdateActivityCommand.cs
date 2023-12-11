using MediatR;
using TimeTracker.Domain;

namespace TimeTracker.Application.Activities.Commands.UpdateActivity
{
    public class UpdateActivityCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Description { get; set; }
        public long StartInMilliseconds { get; set; }
        public long? EndInMilliseconds { get; set; }
        public Project? Project { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
