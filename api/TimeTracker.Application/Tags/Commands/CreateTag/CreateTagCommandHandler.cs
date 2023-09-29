using MediatR;
using TimeTracker.Application.Interfaces;
using TimeTracker.Domain;

namespace TimeTracker.Application.Tags.Commands.CreateTag
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, Guid>
    {
        private readonly ITimeTrackerDbContext dbContext;

        public CreateTagCommandHandler(ITimeTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var tag = new Tag
            { // TODO: add user id
                Title = request.Title,
                CreationDate = DateTime.Now,
                EditDate = null,
                Id = Guid.NewGuid(),
            };

            await dbContext.Tags.AddAsync(tag, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return tag.Id;
        }
    }
}
