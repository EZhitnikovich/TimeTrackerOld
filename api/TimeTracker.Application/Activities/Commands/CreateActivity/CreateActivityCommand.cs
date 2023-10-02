using MediatR;
using TimeTracker.Domain;

namespace TimeTracker.Application.Activities.Commands.CreateActivity
{
    public class CreateActivityCommand : IRequest<Guid>
    {// TODO: add user Id
        public string Description { get; set; }
        public List<Guid> TagIds { get; set; }
        public Guid? ProjectId { get; set; }
        public int StartInMilliseconds { get; set; }
        public int? EndInMilliseconds { get; set; }
    }
}
