using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Application.Common.Exceptions;
using TimeTracker.Application.Interfaces;
using TimeTracker.Domain;

namespace TimeTracker.Application.Activities.Commands.UpdateActivity
{
    public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand, Unit>
    {
        private readonly ITimeTrackerDbContext dbContext;

        public UpdateActivityCommandHandler(ITimeTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
        {
            var activity = await dbContext.Activities.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (activity == null || activity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Activity), request.Id);
            }

            var project = await dbContext.Projects.FirstOrDefaultAsync(x => x.Id == request.ProjectId && x.UserId == request.UserId);
            var tags = await dbContext.Tags.Where(x => request.TagIds != null &&
                                                        x.UserId == request.UserId &&
                                                        request.TagIds.Contains(x.Id)).ToListAsync();

            activity.EditDate = DateTime.Now;
            activity.Description = request.Description;
            activity.Project = project;
            activity.Tags = tags;
            activity.StartInMilliseconds = request.StartInMilliseconds;
            activity.EndInMilliseconds = request.EndInMilliseconds;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
