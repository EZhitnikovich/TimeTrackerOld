using MediatR;

namespace TimeTracker.Application.Tags.Commands.DeleteTag
{
    public class DeleteTagCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
