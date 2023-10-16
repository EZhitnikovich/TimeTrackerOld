using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Application.Projects.Commands.CreateProject;
using TimeTracker.Application.Projects.Commands.DeleteProject;
using TimeTracker.Application.Projects.Commands.UpdateProject;
using TimeTracker.Application.Projects.Queries.GetProjectDetails;
using TimeTracker.Application.Projects.Queries.GetProjectList;
using TimeTracker.Api.Models;
using Microsoft.AspNetCore.Authorization;

namespace TimeTracker.Api.Controllers
{
    public class ProjectController: BaseController
    {
        private readonly IMapper mapper;

        public ProjectController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ProjectListVm>> GetAll()
        {
            var query = new GetProjectListQuery()
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ProjectDetailVm>> Get(Guid id)
        {
            var query = new GetProjectDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProjectDto createProjectDto)
        {
            var command = mapper.Map<CreateProjectCommand>(createProjectDto);
            command.UserId = UserId;
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateProjectDto updateProjectDto)
        {
            var command = mapper.Map<UpdateProjectCommand>(updateProjectDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProjectCommand
            {
                UserId = UserId,
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
