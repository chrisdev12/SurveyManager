using Survey.WebService.Models;
using Survey.WebService.Repository;
using System.Threading.Tasks;

namespace Survey.WebService.Services
{
    public class GeneralSurveyService : IGeneralSurveyService
    {
        private readonly IRepository<SurveyModel> _surveyRepository;

        public GeneralSurveyService(IRepository<SurveyModel> surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        public async Task<OperationStatusEnum> UpdateOrCreate(SurveyModel survey)
        {
            SurveyModel surveyFound = await _surveyRepository.Get(survey.Id);
            if (surveyFound == null)
            {
                await _surveyRepository.Insert(survey);
                return OperationStatusEnum.Created; 
            }
            bool areSurveysEquals = surveyFound.Equals(survey);
            if (!areSurveysEquals)
            {
                await _surveyRepository.Update(survey);
                return OperationStatusEnum.Updated;
            }

            return OperationStatusEnum.Unchanged;
        }
    }
}
