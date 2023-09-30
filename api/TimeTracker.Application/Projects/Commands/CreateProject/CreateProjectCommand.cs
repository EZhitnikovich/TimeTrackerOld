using MediatR;

namespace TimeTracker.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommand: IRequest<Guid>
    { // TODO: add user id
        public string Title { get; set; }
    }
}
