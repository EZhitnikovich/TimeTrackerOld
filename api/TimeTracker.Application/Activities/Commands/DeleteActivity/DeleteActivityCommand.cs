using MediatR;

namespace TimeTracker.Application.Activities.Commands.DeleteActivity
{
    public class DeleteActivityCommand : IRequest
    { // TODO: add user Id
        public Guid Id { get; set; }
    }
}
