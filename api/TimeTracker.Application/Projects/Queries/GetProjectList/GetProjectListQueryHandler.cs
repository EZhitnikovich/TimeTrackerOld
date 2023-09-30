using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Application.Interfaces;

namespace TimeTracker.Application.Projects.Queries.GetProjectList
{
    public class GetProjectListQueryHandler : IRequestHandler<GetProjectListQuery, ProjectListVm>
    {
        private readonly ITimeTrackerDbContext dbContext;
        private readonly IMapper mapper;

        public GetProjectListQueryHandler(ITimeTrackerDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ProjectListVm> Handle(GetProjectListQuery request, CancellationToken cancellationToken)
        {
            var projects = await dbContext.Projects // TODO: add user id
                .ProjectTo<ProjectLookupDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ProjectListVm { Projects = projects };
        }
    }
}
