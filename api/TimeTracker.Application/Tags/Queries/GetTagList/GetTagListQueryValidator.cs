using FluentValidation;

namespace TimeTracker.Application.Tags.Queries.GetTagList
{
    public class GetTagListQueryValidator : AbstractValidator<GetTagListQuery>
    {
        public GetTagListQueryValidator()
        {
            RuleFor(query => query.UserId).NotEqual(Guid.Empty);
        }
    }
}
