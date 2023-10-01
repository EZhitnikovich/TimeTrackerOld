using MediatR;
using TimeTracker.Domain;

namespace TimeTracker.Application.Activities.Commands.CreateActivity
{
    public class CreateActivityCommand : IRequest<Guid>
    {// TODO: add user Id
        public Guid Id { get; set; }
        public string Description { get; set; }
        public List<Tag> Tags { get; set; }
        public Project? Project { get; set; }
        public int StartInMilliseconds { get; set; }
        public int? EndInMilliseconds { get; set; }
    }
}
