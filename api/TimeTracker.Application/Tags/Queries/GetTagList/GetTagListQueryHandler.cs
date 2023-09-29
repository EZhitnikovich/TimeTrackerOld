using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Application.Interfaces;

namespace TimeTracker.Application.Tags.Queries.GetTagList
{
    public class GetTagListQueryHandler : IRequestHandler<GetTagListQuery, TagListVm>
    {
        private readonly ITimeTrackerDbContext dbContext;
        private readonly IMapper mapper;

        public GetTagListQueryHandler(ITimeTrackerDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<TagListVm> Handle(GetTagListQuery request, CancellationToken cancellationToken)
        {
            var tags = await dbContext.Tags // TODO: add user id
                .ProjectTo<TagLookupDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new TagListVm { Tags = tags };
        }
    }
}
