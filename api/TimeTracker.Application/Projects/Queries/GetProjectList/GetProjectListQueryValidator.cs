using FluentValidation;

namespace TimeTracker.Application.Projects.Queries.GetProjectList
{
    public class GetProjectListQueryValidator: AbstractValidator<GetProjectListQuery>
    {
        public GetProjectListQueryValidator()
        {
            RuleFor(query => query.UserId).NotEqual(Guid.Empty);
        }
    }
}
