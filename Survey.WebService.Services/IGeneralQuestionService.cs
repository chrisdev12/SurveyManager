using Survey.WebService.Models;
using Survey.WebService.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Survey.WebService.Services
{
    public interface IGeneralQuestionService
    {
        public Task<List<QuestionStatusDTO>> UpdateOrCreate(List<QuestionModel> questionListReceived, SurveyModel survey);
    }
}
