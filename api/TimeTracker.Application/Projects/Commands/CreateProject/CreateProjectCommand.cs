using MediatR;

namespace TimeTracker.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommand: IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
    }
}
