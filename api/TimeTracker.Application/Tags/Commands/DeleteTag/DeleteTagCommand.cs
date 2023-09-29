using MediatR;

namespace TimeTracker.Application.Tags.Commands.DeleteTag
{
    public class DeleteTagCommand : IRequest
    { // TODO: add user id
        public Guid Id { get; set; }
    }
}
