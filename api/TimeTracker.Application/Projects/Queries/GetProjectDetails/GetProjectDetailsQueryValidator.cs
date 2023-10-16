using FluentValidation;

namespace TimeTracker.Application.Projects.Queries.GetProjectDetails
{
    public class GetProjectDetailsQueryValidator: AbstractValidator<GetProjectDetailsQuery>
    {
        public GetProjectDetailsQueryValidator()
        {
            RuleFor(query => query.Id).NotEqual(Guid.Empty);
            RuleFor(query => query.UserId).NotEqual(Guid.Empty);
        }
    }
}
