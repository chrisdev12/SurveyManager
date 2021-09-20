using Microsoft.AspNetCore.Mvc;
using Survey.WebService.Models.DTO;
using Survey.WebService.Responses;
using Survey.WebService.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Survey.WebService.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AspectController : Controller
    {
        private readonly IAspectService _aspectService;
        public AspectController(IAspectService aspectService)
        {
            _aspectService = aspectService;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<List<AspectRequestDTO>>>> Register([FromBody] AspectRequestDTO Request)
        {
            try
            {
                var response = await _aspectService.VerifySurveyExistence(Request);
                return Ok(new ApiResponse<List<AspectRequestDTO>> { Data = response });
            }
            catch (SqlException)
            {
                return Problem("database error connection");
            }
            catch(Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
