using MediatR;

namespace TimeTracker.Application.Tags.Queries.GetTagDetails
{
    public class GetTagDetailsQuery: IRequest<TagDetailVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
