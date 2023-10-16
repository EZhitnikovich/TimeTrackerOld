using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Application.Common.Exceptions;
using TimeTracker.Application.Interfaces;
using TimeTracker.Domain;

namespace TimeTracker.Application.Activities.Commands.StopActivity
{
    public class StopActivityCommandHandler : IRequestHandler<StopActivityCommand, Unit>
    {
        private readonly ITimeTrackerDbContext dbContext;

        public StopActivityCommandHandler(ITimeTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(StopActivityCommand request, CancellationToken cancellationToken)
        {
            var activity = await dbContext.Activities.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (activity == null || activity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Activity), request.Id);
            }

            if (activity.EndInMilliseconds == null)
            {
                activity.EndInMilliseconds = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                await dbContext.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
