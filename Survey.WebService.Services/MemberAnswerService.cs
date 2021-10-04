using Survey.WebService.Models;
using Survey.WebService.Models.DTOs;
using Survey.WebService.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Survey.WebService.Services
{
    public class MemberAnswerService : IMemberAnswerService
    {
        private readonly IMemberRepository _memberRepository;
        public MemberAnswerService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public async Task UpdateOrCreate(GeneralSurveyRequestDTO aspectRequest)
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
