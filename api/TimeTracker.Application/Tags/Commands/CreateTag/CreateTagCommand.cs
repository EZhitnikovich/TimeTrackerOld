using MediatR;

namespace TimeTracker.Application.Tags.Commands.CreateTag
{
    public class CreateTagCommand: IRequest<Guid>
    { // TODO: add user id
        public string Title { get; set; }
    }
}
