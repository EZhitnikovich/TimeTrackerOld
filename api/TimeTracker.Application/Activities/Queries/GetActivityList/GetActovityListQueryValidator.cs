using FluentValidation;

namespace TimeTracker.Application.Activities.Queries.GetActivityList
{
    public class GetActovityListQueryValidator : AbstractValidator<GetActivityListQuery>
    {
        public GetActovityListQueryValidator()
        {
            RuleFor(query => query.UserId).NotEqual(Guid.Empty);
        }
    }
}
