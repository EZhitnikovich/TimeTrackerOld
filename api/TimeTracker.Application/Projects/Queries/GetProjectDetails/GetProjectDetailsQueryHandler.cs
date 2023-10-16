using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Application.Common.Exceptions;
using TimeTracker.Application.Interfaces;
using TimeTracker.Domain;

namespace TimeTracker.Application.Projects.Queries.GetProjectDetails
{
    public class GetProjectDetailsQueryHandler : IRequestHandler<GetProjectDetailsQuery, ProjectDetailVm>
    {
        private readonly ITimeTrackerDbContext dbContext;
        private readonly IMapper mapper;

        public GetProjectDetailsQueryHandler(ITimeTrackerDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ProjectDetailVm> Handle(GetProjectDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Projects.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if(entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            return mapper.Map<ProjectDetailVm>(entity);
        }
    }
}
