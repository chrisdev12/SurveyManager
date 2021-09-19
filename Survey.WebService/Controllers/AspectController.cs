using Microsoft.AspNetCore.Mvc;
using Survey.WebService.Models.Aspect;
using Survey.WebService.Responses;
using Survey.WebService.Services;

namespace Survey.WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AspectController : Controller
    {
        private readonly IAspectService _aspectService;
        public AspectController(IAspectService aspectService)
        {
            this._aspectService = aspectService;
        }

        [HttpPost("[action]")]
        public ActionResult<ApiResponse<string>> Register([FromBody] AspectRequestDTO Request)
        {
            var response = _aspectService.GetAll();
            return Ok(new ApiResponse<string>{ Data = response });
        }
    }
}
