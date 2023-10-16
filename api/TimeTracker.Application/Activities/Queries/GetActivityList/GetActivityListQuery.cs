using MediatR;

namespace TimeTracker.Application.Activities.Queries.GetActivityList
{
    public class GetActivityListQuery : IRequest<ActivityListVm>
    {
        public Guid UserId { get; set; }
    }
}
