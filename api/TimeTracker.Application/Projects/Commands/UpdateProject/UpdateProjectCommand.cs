using MediatR;

namespace TimeTracker.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommand: IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
