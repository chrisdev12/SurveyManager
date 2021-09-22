using Survey.WebService.Models;
using Survey.WebService.Models.DTOs;
using Survey.WebService.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Survey.WebService.Services
{
    public class GeneralSurveyService : IGeneralSurveyService
    {
        private readonly IRepository<SurveyModel> _surveyRepository;
        private readonly IRepository<QuestionModel> _questionRepository;
        public GeneralSurveyService(IRepository<SurveyModel> surveyRepository, IRepository<QuestionModel> questionRepository)
        {
            _surveyRepository = surveyRepository;
            _questionRepository = questionRepository;
        }
        public async Task<GeneralSurveyResponseDTO> BusinessRegistration(GeneralSurveyRequestDTO aspectRequest)
        {
            // Business flow: 
            // Verify if survey is equal or not
            // Verify if question are equal or not
            // Answer pending.
            //Sino hay se inserta
            var survey = await _surveyRepository.Get();
            if(survey == null) {
                RegisterNewOne();
            } else {
                UpdateExisting();
            };

            var questions = await _questionRepository.GetAll();
            // comparo objetos
            //inserta respuesta ---> 
            return new GeneralSurveyResponseDTO() {};
        }

        public void RegisterNewOne()
        {

        }

        public void UpdateExisting()
        {

        }
    }
}
