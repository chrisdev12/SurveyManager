using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Survey.WebService.Filters;
using Survey.WebService.Models.DTOs;
using Survey.WebService.Responses;
using Survey.WebService.Services;
using System;
using System.Threading.Tasks;

namespace Survey.WebService.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class GeneralSurveyController : Controller
    {
        private readonly IGeneralSurveyService _surveyService;
        private readonly IGeneralQuestionService _questionService;
        private readonly IMemberAnswerService _memberAnswerService;
        private readonly ILogger<GeneralSurveyController> _logger;
        public GeneralSurveyController(
            IGeneralSurveyService surveyService, 
            ILogger<GeneralSurveyController> logger,
            IGeneralQuestionService questionService,
            IMemberAnswerService memberAnswerService
        )
        {
            _surveyService = surveyService;
            _logger = logger;
            _questionService = questionService;
            _memberAnswerService = memberAnswerService;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<GeneralSurveyResponseDTO>>> 
            Register([FromJsonQueryIsRequiered(Name = "body")] GeneralSurveyRequestDTO Request)
        {
            try
            {
                var surveyStatus = await _surveyService.UpdateOrCreate(Request.Survey);
                var questionStatusList = await _questionService.UpdateOrCreate(Request.Questions, Request.Survey);
                await _memberAnswerService.UpdateOrCreate(Request);

                var response = new GeneralSurveyResponseDTO()
                {
                    SurveyId = Request.Survey.Id,
                    MemberNumber = Request.MemberInfo.MemberNumber,
                    AdditionalMessage = new
                    {
                        SurveyStatus = surveyStatus.ToString(),
                        QuestionStatusList = questionStatusList
                    }
                };

                return Ok(new ApiResponse<GeneralSurveyResponseDTO> { Data = response });
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());
                return Problem(e.Message);
            }
        }
    }
}
