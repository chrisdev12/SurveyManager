using System.Collections.Generic;

namespace Survey.WebService.Models.DTOs
{
    public class GeneralSurveyRequestDTO
    {
        public SurveyModel Survey { get; set; }
        public IEnumerable<QuestionModel> Questions { get; set; }
        public IEnumerable<AnswerModel> Answers { get; set; }
        public MemberModel MemberInfo { get; set; }
    }
}
