using MediatR;

namespace TimeTracker.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
