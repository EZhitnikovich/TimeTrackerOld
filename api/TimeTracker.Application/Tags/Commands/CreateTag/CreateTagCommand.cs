using MediatR;

namespace TimeTracker.Application.Tags.Commands.CreateTag
{
    public class CreateTagCommand: IRequest<Guid>
    {
        public string Title { get; set; }
    }
}
