using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Application.Activities.Commands.CreateActivity;
using TimeTracker.Application.Activities.Commands.DeleteActivity;
using TimeTracker.Application.Activities.Commands.StartActivity;
using TimeTracker.Application.Activities.Commands.StopActivity;
using TimeTracker.Application.Activities.Commands.UpdateActivity;
using TimeTracker.Application.Activities.Queries.GetActivityList;
using TimeTracker.Api.Models;
using Microsoft.AspNetCore.Authorization;

namespace TimeTracker.Api.Controllers
{
    public class ActivityController : BaseController
    {
        private readonly IMapper mapper;

        public ActivityController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ActivityListVm>> GetAll()
        {
            var command = new GetActivityListQuery()
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateActivityDto createActivityDto)
        {
            var command = mapper.Map<CreateActivityCommand>(createActivityDto);
            command.UserId = UserId;
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateActivityDto updateActivityDto)
        {
            var command = mapper.Map<UpdateActivityCommand>(updateActivityDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteActivityCommand
            {
                UserId = UserId,
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Start([FromBody] StartActivityDto startActivityDto)
        {
            var command = mapper.Map<StartActivityCommand>(startActivityDto);
            command.UserId = UserId;
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Stop(Guid id)
        {
            var command = new StopActivityCommand { Id = id, UserId = UserId };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
