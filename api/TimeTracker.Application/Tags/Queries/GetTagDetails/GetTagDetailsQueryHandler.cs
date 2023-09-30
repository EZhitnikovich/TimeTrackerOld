using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Application.Common.Exceptions;
using TimeTracker.Application.Interfaces;
using TimeTracker.Domain;

namespace TimeTracker.Application.Tags.Queries.GetTagDetails
{
    public class GetTagDetailsQueryHandler : IRequestHandler<GetTagDetailsQuery, TagDetailVm>
    {
        private readonly ITimeTrackerDbContext dbContext;
        private readonly IMapper mapper;

        public GetTagDetailsQueryHandler(ITimeTrackerDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<TagDetailVm> Handle(GetTagDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Tags.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)  // TODO: add user id
            {
                throw new NotFoundException(nameof(Tag), request.Id);
            }

            return mapper.Map<TagDetailVm>(entity);
        }
    }
}
