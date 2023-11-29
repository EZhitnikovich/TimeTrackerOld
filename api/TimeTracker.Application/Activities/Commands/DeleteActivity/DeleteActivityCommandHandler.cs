using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Application.Common.Exceptions;
using TimeTracker.Application.Interfaces;
using TimeTracker.Domain;

namespace TimeTracker.Application.Activities.Commands.DeleteActivity
{
    public class DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommand, Unit>
    {
        private readonly ITimeTrackerDbContext dbContext;

        public DeleteActivityCommandHandler(ITimeTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
        {
            var activity = await dbContext.Activities
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (activity == null || activity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            dbContext.Activities.Remove(activity);
            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
