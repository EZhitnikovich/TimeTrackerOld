using Microsoft.AspNetCore.Mvc;

namespace TimeTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ILogger<TagsController> logger;
        public TagsController(ILogger<TagsController> logger)
        {
            this.logger = logger;
        }

        //[HttpGet(Name = "GetTags")]
        //public IEnumerable<Tag> Get()
        //{
        //    return tags;
        //}
    }
}
