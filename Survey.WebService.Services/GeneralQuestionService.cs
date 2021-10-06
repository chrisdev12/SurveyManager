using Survey.WebService.Models;
using Survey.WebService.Models.DTOs;
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
        public async Task<List<QuestionStatusDTO>> UpdateOrCreate(List<QuestionModel> questionListReceived, SurveyModel survey)
        {
            var questionStatusList = new List<QuestionStatusDTO>();
            var questionListFound = await _questionRepository.GetAll(survey.Id);
            foreach (QuestionModel question in questionListReceived)
            {
                var questionStatus = new QuestionStatusDTO { QuestionId = question.Id };
                questionStatus.SetStatus(OperationStatusEnum.Unchanged);
                question.SurveyId = survey.Id;
                QuestionModel questionMatch = questionListFound.Find(x => x.Id == question.Id);
                if (questionMatch == null)
                {
                    await _questionRepository.Insert(question);
                    questionStatus.SetStatus(OperationStatusEnum.Created);
                    questionStatusList.Add(questionStatus);
                    continue;
                }
                var questionHasChanged = !question.Equals(questionMatch);
                if (questionHasChanged)
                {
                    await _questionRepository.Update(question);
                    questionStatus.SetStatus(OperationStatusEnum.Updated);
                }

                questionStatusList.Add(questionStatus);
            };

            return questionStatusList;
        }
    }
}
