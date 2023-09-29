using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Application.Common.Exceptions;
using TimeTracker.Application.Interfaces;
using TimeTracker.Domain;

namespace TimeTracker.Application.Tags.Commands.DeleteTag
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand>
    {
        private readonly ITimeTrackerDbContext dbContext;

        public DeleteTagCommandHandler(ITimeTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Tags.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null) // TODO: add user id
            {
                throw new NotFoundException(nameof(Tag), request.Id);
            }

            dbContext.Tags.Remove(entity);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
