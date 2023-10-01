using MediatR;
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
            var activity = new Activity
            {
                Id = request.Id, // TODO: maybe i should remove id here
                CreationDate = DateTime.Now,
                Description = request.Description,
                EditDate = null,
                EndInMilliseconds = request.EndInMilliseconds,
                StartInMilliseconds = request.StartInMilliseconds,
                Project = request.Project,
                Tags = request.Tags,
            };

            await dbContext.Activities.AddAsync(activity, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return activity.Id;
        }
    }
}
