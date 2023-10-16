using MediatR;

namespace TimeTracker.Application.Tags.Commands.UpdateTag
{
    public class UpdateTagCommand: IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
