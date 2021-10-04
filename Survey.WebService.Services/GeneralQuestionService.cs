using Survey.WebService.Models;
using Survey.WebService.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Survey.WebService.Services
{
    public class GeneralQuestionService : IGeneralQuestionService
    {
        private readonly IRepository<QuestionModel> _questionRepository;
        public GeneralQuestionService(IRepository<QuestionModel> questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public async Task<OperationStatusEnum> UpdateOrCreate(List<QuestionModel> questionListReceived, SurveyModel survey)
        {
            var operationStatus = OperationStatusEnum.Unchanged;
            var questionListFound = await _questionRepository.GetAll(survey.Id);
            foreach (QuestionModel question in questionListReceived)
            {
                question.SurveyId = survey.Id;
                QuestionModel questionMatch = questionListFound.Find(x => x.Id == question.Id);
                if (questionMatch == null)
                {
                    await _questionRepository.Insert(question);
                    operationStatus = OperationStatusEnum.Created;
                    continue;
                }
                questionMatch.SurveyId = survey.Id;
                bool areQuestionEqual = question.Equals(questionMatch);
                if (!areQuestionEqual)
                {
                    await _questionRepository.Update(question);
                    operationStatus = OperationStatusEnum.Updated;
                }

                continue;
            }

            return operationStatus;
        }
    }
}
