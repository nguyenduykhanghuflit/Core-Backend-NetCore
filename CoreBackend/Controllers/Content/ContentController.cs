
using CoreBackend.Helpers.ActionFilters;
using CoreBackend.Helpers.Api;
using Microsoft.AspNetCore.Mvc;

namespace CoreBackend.Controllers.Content
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ContentWorkFlow contentWorkFlow;
        public ContentController(IConfiguration configuration)
        {
            contentWorkFlow = new ContentWorkFlow(configuration);
            this.configuration = configuration;
        }

        [HttpGet("/api/Content")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Get([FromQuery] ContentTypeRequest req)
        {
            var data = contentWorkFlow.GetContents(req.ContentType);

            var res = Helpers.Api.Response.Success(data, "Get content", "Get successfully");
            return Ok(res);
        }
    }
}
