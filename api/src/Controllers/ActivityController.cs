using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Application.Activities.Commands.CreateActivity;
using TimeTracker.Application.Activities.Commands.DeleteActivity;
using TimeTracker.Application.Activities.Commands.UpdateActivity;
using TimeTracker.Application.Activities.Queries.GetActivityList;
using TimeTrackerApi.Models;

namespace TimeTrackerApi.Controllers
{
    [Route("api/[controller]")]
    public class ActivityController: BaseController
    {
        private readonly IMapper mapper;

        public ActivityController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ActivityListVm>> GetAll()
        {
            var command = new GetActivityListQuery(); // TODO: add user id
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateActivityDto createActivityDto)
        {
            var command = mapper.Map<CreateActivityCommand>(createActivityDto);
            // TODO: add user id
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateActivityDto updateActivityDto)
        {
            var command = mapper.Map<UpdateActivityCommand>(updateActivityDto);
            // TODO: add user id
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteActivityCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
