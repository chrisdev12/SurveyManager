using Microsoft.AspNetCore.Mvc;
using Survey.WebService.Models.DTOs;
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
    public class GeneralSurvey : Controller
    {
        private readonly IGeneralSurveyService _surveyService;
        public GeneralSurvey(IGeneralSurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<GeneralSurveyResponseDTO>>> Register([FromBody] GeneralSurveyRequestDTO Request)
        {
            try
            {
                var response = await _surveyService.BusinessRegistration(Request);
                return Ok(new ApiResponse<GeneralSurveyResponseDTO> { Data = response });
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
