using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Survey.WebService.Models.DTOs;
using Survey.WebService.Responses;
using Survey.WebService.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Survey.WebService.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class GeneralSurveyController : Controller
    {
        private readonly IGeneralSurveyService _surveyService;
        private readonly ILogger<GeneralSurveyController> _logger;
        public GeneralSurveyController(IGeneralSurveyService surveyService, ILogger<GeneralSurveyController> logger)
        {
            _surveyService = surveyService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<GeneralSurveyResponseDTO>>> Register([FromBody] GeneralSurveyRequestDTO Request)
        {
            try
            {
                var response = await _surveyService.BusinessRegistration(Request);
                return Ok(new ApiResponse<GeneralSurveyResponseDTO> { Data = response });
            }
            catch (SqlException e)
            {
                _logger.LogError(e.ToString());
                return Problem(e.Message);
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());
                return Problem(e.Message);
            }
        }
    }
}
