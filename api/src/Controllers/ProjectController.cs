using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Application.Projects.Commands.CreateProject;
using TimeTracker.Application.Projects.Commands.DeleteProject;
using TimeTracker.Application.Projects.Commands.UpdateProject;
using TimeTracker.Application.Projects.Queries.GetProjectDetails;
using TimeTracker.Application.Projects.Queries.GetProjectList;
using TimeTrackerApi.Models;

namespace TimeTrackerApi.Controllers
{
    public class ProjectController: BaseController
    {
        private readonly IMapper mapper;

        public ProjectController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ProjectListVm>> GetAll()
        {
            var query = new GetProjectListQuery(); // TODO: add user id 
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDetailVm>> Get(Guid id)
        {
            var query = new GetProjectDetailsQuery // TODO: add user id
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProjectDto createProjectDto)
        {
            var command = mapper.Map<CreateProjectCommand>(createProjectDto);
            // TODO: add user id
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProjectDto updateProjectDto)
        {
            var command = mapper.Map<UpdateProjectCommand>(updateProjectDto);
            // TODO: add user id
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProjectCommand
            {
                Id = id
            };
            // TODO: add user id
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
