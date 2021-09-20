using Survey.WebService.Models;
using Survey.WebService.Models.DTO;
using Survey.WebService.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Survey.WebService.Services
{
    public class AspectService : IAspectService
    {
        private readonly IRepository<SurveyModel> _surveyRepository;
        private readonly IRepository<QuestionModel> _questionRepository;
        public AspectService(IRepository<SurveyModel> surveyRepository, IRepository<QuestionModel> questionRepository)
        {
            _surveyRepository = surveyRepository;
            _questionRepository = questionRepository;
        }
        public async Task<List<AspectRequestDTO>> VerifySurveyExistence(AspectRequestDTO aspectRequest)
        {
            // Business flow: 
            // Verify if survey is equal or not
            // Verify if question are equal or not
            // Answer pending.
            var survey = await _surveyRepository.Get();
            var questions = await _questionRepository.GetAll();
            return new List<AspectRequestDTO>();
        }
    }
}
