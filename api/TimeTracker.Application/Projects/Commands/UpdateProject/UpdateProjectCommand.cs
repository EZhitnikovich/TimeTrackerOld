using MediatR;

namespace TimeTracker.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommand: IRequest<Unit>
    { // TODO: add user id
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
