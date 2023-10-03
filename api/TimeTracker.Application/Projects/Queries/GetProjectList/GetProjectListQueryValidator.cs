using FluentValidation;

namespace TimeTracker.Application.Projects.Queries.GetProjectList
{
    public class GetProjectListQueryValidator: AbstractValidator<GetProjectListQuery>
    {
        public GetProjectListQueryValidator()
        {
            // TODO: add user id
        }
    }
}
