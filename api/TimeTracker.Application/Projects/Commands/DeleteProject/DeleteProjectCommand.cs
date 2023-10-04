using MediatR;

namespace TimeTracker.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest<Unit>
    { // TODO: add user id
        public Guid Id { get; set; }
    }
}
