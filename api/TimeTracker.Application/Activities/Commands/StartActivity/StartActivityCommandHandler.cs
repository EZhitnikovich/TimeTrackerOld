using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Application.Interfaces;
using TimeTracker.Domain;

namespace TimeTracker.Application.Activities.Commands.StartActivity
{
    public class StartActivityCommandHandler : IRequestHandler<StartActivityCommand, Guid>
    {
        private readonly ITimeTrackerDbContext dbContext;

        public StartActivityCommandHandler(ITimeTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Guid> Handle(StartActivityCommand request, CancellationToken cancellationToken)
        {
            var project = await dbContext.Projects.FirstOrDefaultAsync(x => x.Id == request.ProjectId);
            // TODO: check if user have access to project

            var tags = await dbContext.Tags.Where(x => request.TagIds.Contains(x.Id)).ToListAsync();
            // TODO: check if user have access to tags

            var activity = new Activity
            {
                Id = Guid.NewGuid(),
                Description = request.Description,
                Tags = tags,
                Project = project,
                CreationDate = DateTime.Now,
                EditDate = null,
                StartInMilliseconds = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                EndInMilliseconds = null,
            };

            await dbContext.Activities.AddAsync(activity, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            return activity.Id;
        }
    }
}
