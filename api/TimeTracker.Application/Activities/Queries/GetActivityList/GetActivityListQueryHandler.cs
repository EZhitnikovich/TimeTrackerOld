using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Application.Interfaces;

namespace TimeTracker.Application.Activities.Queries.GetActivityList
{
    public class GetActivityListQueryHandler : IRequestHandler<GetActivityListQuery, ActivityListVm>
    {
        private readonly ITimeTrackerDbContext dbContext;
        private readonly IMapper mapper;

        public GetActivityListQueryHandler(ITimeTrackerDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ActivityListVm> Handle(GetActivityListQuery request, CancellationToken cancellationToken)
        {
            var activities = await dbContext.Activities // TODO: add user id
                .Include(x => x.Project).Include(x => x.Tags) 
                .ProjectTo<ActivityLookupDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ActivityListVm { Activities = activities };
        }
    }
}
