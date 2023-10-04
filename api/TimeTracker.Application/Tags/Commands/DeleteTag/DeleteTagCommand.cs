using MediatR;

namespace TimeTracker.Application.Tags.Commands.DeleteTag
{
    public class DeleteTagCommand : IRequest<Unit>
    { // TODO: add user id
        public Guid Id { get; set; }
    }
}
