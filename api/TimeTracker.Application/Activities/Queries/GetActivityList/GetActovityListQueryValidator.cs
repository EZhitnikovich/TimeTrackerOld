using FluentValidation;

namespace TimeTracker.Application.Activities.Queries.GetActivityList
{
    public class GetActovityListQueryValidator : AbstractValidator<GetActivityListQuery>
    {
        public GetActovityListQueryValidator()
        {
            // TODO: add user id
        }
    }
}
