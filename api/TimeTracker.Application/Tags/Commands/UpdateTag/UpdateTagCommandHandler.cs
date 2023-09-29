using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Application.Common.Exceptions;
using TimeTracker.Application.Interfaces;
using TimeTracker.Domain;

namespace TimeTracker.Application.Tags.Commands.UpdateTag
{
    internal class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand>
    {
        private readonly ITimeTrackerDbContext dbContext;

        public UpdateTagCommandHandler(ITimeTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Tags.FirstOrDefaultAsync(tag => tag.Id == request.Id, cancellationToken);

            if(entity == null) // TODO: add user id
            {
                throw new NotFoundException(nameof(Tag), request.Id);
            }

            entity.EditDate = DateTime.Now;
            entity.Title = request.Title;

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
