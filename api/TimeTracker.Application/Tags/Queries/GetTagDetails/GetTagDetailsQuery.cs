using MediatR;

namespace TimeTracker.Application.Tags.Queries.GetTagDetails
{
    public class GetTagDetailsQuery: IRequest<TagDetailVm>
    {
        public Guid Id { get; set; }
    }
}
