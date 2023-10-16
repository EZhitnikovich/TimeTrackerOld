using MediatR;

namespace TimeTracker.Application.Tags.Queries.GetTagList
{
    public class GetTagListQuery: IRequest<TagListVm>
    {
        public Guid UserId { get; set; }
    }
}
