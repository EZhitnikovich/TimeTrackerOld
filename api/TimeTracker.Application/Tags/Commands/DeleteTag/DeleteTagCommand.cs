using MediatR;

namespace TimeTracker.Application.Tags.Commands.DeleteTag
{
    public class DeleteTagCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
