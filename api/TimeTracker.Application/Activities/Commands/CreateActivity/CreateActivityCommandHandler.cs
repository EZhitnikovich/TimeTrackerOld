using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Application.Interfaces;
using TimeTracker.Domain;

namespace TimeTracker.Application.Activities.Commands.CreateActivity
{
    public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, Guid>
    {
        private readonly ITimeTrackerDbContext dbContext;

        public CreateActivityCommandHandler(ITimeTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            var project = await dbContext.Projects.FirstOrDefaultAsync(x => x.Id == request.ProjectId && x.UserId == request.UserId);
            var tags = await dbContext.Tags.Where(x => x.UserId == request.UserId && request.TagIds.Contains(x.Id)).ToListAsync();

            var activity = new Activity
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                CreationDate = DateTime.Now,
                Description = request.Description,
                EditDate = null,
                EndInMilliseconds = request.EndInMilliseconds,
                StartInMilliseconds = request.StartInMilliseconds,
                Project = project,
                Tags = tags,
            };

            await dbContext.Activities.AddAsync(activity, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return activity.Id;
        }
    }
}
