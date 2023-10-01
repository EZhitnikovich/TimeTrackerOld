using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Application.Common.Exceptions;
using TimeTracker.Application.Interfaces;
using TimeTracker.Domain;

namespace TimeTracker.Application.Activities.Commands.UpdateActivity
{
    public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand>
    {
        private readonly ITimeTrackerDbContext dbContext;

        public UpdateActivityCommandHandler(ITimeTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
        {
            var activity = await dbContext.Activities.FirstOrDefaultAsync(x=> x.Id == request.Id, cancellationToken);

            if (activity == null)
            {
                throw new NotFoundException(nameof(Activity), request.Id);
            }

            activity.EditDate = DateTime.Now;
            activity.Description = request.Description;
            activity.Project = request.Project;
            activity.Tags = request.Tags; // TODO: check tags
            activity.StartInMilliseconds = request.StartInMilliseconds;
            activity.EndInMilliseconds = request.EndInMilliseconds;

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
