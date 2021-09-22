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
        private readonly IMemberRepository _memberRepository;
        private string actionExecuted;
        public GeneralSurveyService(IRepository<SurveyModel> surveyRepository, IRepository<QuestionModel> questionRepository, IMemberRepository memberRepository)
        {
            _surveyRepository = surveyRepository;
            _questionRepository = questionRepository;
            _memberRepository = memberRepository;
        }
        public async Task<GeneralSurveyResponseDTO> BusinessRegistration(GeneralSurveyRequestDTO aspectRequest)
        {
            await SurveyProcess(aspectRequest.Survey);
            await QuestionProcess(aspectRequest.Questions, aspectRequest.Survey);
            await MemberAnswerProcess(aspectRequest);

            return new GeneralSurveyResponseDTO() 
            {
                SurveyId = aspectRequest.Survey.Id,
                MemberNumber = aspectRequest.MemberInfo.MemberNumber,
                AdditionalMessage = actionExecuted
            };
        }

        public async Task SurveyProcess(SurveyModel survey)
        {
            SurveyModel surveyFound = await _surveyRepository.Get(survey.Id);
            if (surveyFound == null)
            {
                await _surveyRepository.Insert(survey);
                actionExecuted = "Survey created";
                return;
            }
            bool areSurveysEquals = surveyFound.Equals(survey);
            if (!areSurveysEquals)
            {
                await _surveyRepository.Update(survey);
                actionExecuted = "Survey updated";
            }
            else
            {
                actionExecuted = "Survey remains unchanged";
            }
        }

        public async Task QuestionProcess(List<QuestionModel> questionListReceived, SurveyModel survey)
        {
            var questionListFound = await _questionRepository.GetAll(survey.Id);
            foreach (QuestionModel question in questionListReceived)
            {
                question.SurveyId = survey.Id;
                QuestionModel questionMatch = questionListFound.Find(x => x.Id == question.Id);
                if (questionMatch == null)
                {
                    await _questionRepository.Insert(question);
                    continue;
                }
                questionMatch.SurveyId = survey.Id;
                bool areQuestionEqual = question.Equals(questionMatch);
                if(!areQuestionEqual) await _questionRepository.Update(question);

                continue;
            }
        }

        public async Task MemberAnswerProcess(GeneralSurveyRequestDTO aspectRequest)
        {
            List<AnswerModel> answersList = aspectRequest.Answers;
            foreach (AnswerModel answer in answersList)
            {
                QuestionModel questionIdExist = aspectRequest.Questions.Find(x => x.Id == answer.AnswerId);
                if (questionIdExist == null) continue;
                MemberResultDTO newResult = new MemberResultDTO()
                {
                    Survey = aspectRequest.Survey,
                    Answer = answer,
                    Member = aspectRequest.MemberInfo,
                };

                await _memberRepository.Register(newResult);
            }
        }
    }
}
