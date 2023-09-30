using MediatR;

namespace TimeTracker.Application.Projects.Queries.GetProjectDetails
{
    public class GetProjectDetailsQuery: IRequest<ProjectDetailVm>
    {
        public Guid Id { get; set; }
    }
}
