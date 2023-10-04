using MediatR;

namespace TimeTracker.Application.Activities.Commands.DeleteActivity
{
    public class DeleteActivityCommand : IRequest<Unit>
    { // TODO: add user Id
        public Guid Id { get; set; }
    }
}
