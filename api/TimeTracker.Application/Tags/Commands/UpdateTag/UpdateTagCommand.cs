using MediatR;

namespace TimeTracker.Application.Tags.Commands.UpdateTag
{
    public class UpdateTagCommand: IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
