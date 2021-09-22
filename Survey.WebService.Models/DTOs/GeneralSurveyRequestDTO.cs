using System.Collections.Generic;

namespace Survey.WebService.Models.DTOs
{
    public class GeneralSurveyRequestDTO
    {
        public SurveyModel Survey { get; set; }
        public List<QuestionModel> Questions { get; set; }
        public List<AnswerModel> Answers { get; set; }
        public MemberModel MemberInfo { get; set; }
    }
}
