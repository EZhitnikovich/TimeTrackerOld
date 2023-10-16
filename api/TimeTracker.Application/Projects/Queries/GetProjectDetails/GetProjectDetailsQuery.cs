using MediatR;

namespace TimeTracker.Application.Projects.Queries.GetProjectDetails
{
    public class GetProjectDetailsQuery: IRequest<ProjectDetailVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
