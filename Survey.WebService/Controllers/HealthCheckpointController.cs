using Microsoft.AspNetCore.Mvc;
using Survey.WebService.Responses;

namespace Survey.WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckpointController : Controller
    {
        public static readonly string apiWorkingMessage = "Survey Webservice/API is working properly";

        [HttpGet]
        public ActionResult<ApiResponse<string>> Index()
        {
            return  new ApiResponse<string>() { Data = apiWorkingMessage };
        }
    }
}
