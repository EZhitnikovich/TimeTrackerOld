using MediatR;

namespace TimeTracker.Application.Projects.Queries.GetProjectList
{
    public class GetProjectListQuery: IRequest<ProjectListVm>
    {
        public Guid UserId { get; set; }
    }
}
