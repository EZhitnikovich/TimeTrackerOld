using FluentValidation;

namespace TimeTracker.Application.Tags.Queries.GetTagList
{
    public class GetTagListQueryValidator : AbstractValidator<GetTagListQuery>
    {
        public GetTagListQueryValidator()
        {
            // TODO: add user id
        }
    }
}
