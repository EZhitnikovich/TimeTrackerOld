using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Application.Tags.Commands.CreateTag;
using TimeTracker.Application.Tags.Commands.DeleteTag;
using TimeTracker.Application.Tags.Commands.UpdateTag;
using TimeTracker.Application.Tags.Queries.GetTagDetails;
using TimeTracker.Application.Tags.Queries.GetTagList;
using TimeTracker.Api.Models;
using Microsoft.AspNetCore.Authorization;

namespace TimeTracker.Api.Controllers
{
    public class TagsController : BaseController // TOOD: check exceptions
    {
        private readonly IMapper mapper;

        public TagsController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<TagListVm>> GetAll()
        {
            var query = new GetTagListQuery(); // TODO: add user id
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<TagDetailVm>> Get(Guid id)
        {
            var query = new GetTagDetailsQuery // TODO: add user id
            {
                Id = id,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTagDto createTagDto)
        {
            var command = mapper.Map<CreateTagCommand>(createTagDto);
            // TODO: add user id
            var tagId = await Mediator.Send(command);
            return Ok(tagId);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateTagDto updateTagDto)
        {
            var command = mapper.Map<UpdateTagCommand>(updateTagDto);
            // TODO: add user id
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteTagCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
