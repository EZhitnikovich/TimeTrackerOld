using MediatR;

namespace TimeTracker.Application.Tags.Commands.CreateTag
{
    public class CreateTagCommand: IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
    }
}
