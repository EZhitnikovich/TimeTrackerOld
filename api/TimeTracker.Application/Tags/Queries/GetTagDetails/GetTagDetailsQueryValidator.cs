using FluentValidation;

namespace TimeTracker.Application.Tags.Queries.GetTagDetails
{
    public class GetTagDetailsQueryValidator: AbstractValidator<GetTagDetailsQuery>
    {
        public GetTagDetailsQueryValidator()
        {
            RuleFor(query => query.Id).NotEqual(Guid.Empty);
            RuleFor(query => query.UserId).NotEqual(Guid.Empty);
        }
    }
}
