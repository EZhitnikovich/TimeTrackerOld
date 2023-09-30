using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Application.Common.Exceptions;
using TimeTracker.Application.Interfaces;
using TimeTracker.Domain;

namespace TimeTracker.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly ITimeTrackerDbContext dbContext;

        public DeleteProjectCommandHandler(ITimeTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Projects.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null) // TODO: add user id
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            dbContext.Projects.Remove(entity);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
