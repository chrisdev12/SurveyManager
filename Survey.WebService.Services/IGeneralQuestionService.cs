using Survey.WebService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Survey.WebService.Services
{
    public interface IGeneralQuestionService
    {
        public Task<OperationStatusEnum> UpdateOrCreate(List<QuestionModel> questionListReceived, SurveyModel survey);
    }
}
