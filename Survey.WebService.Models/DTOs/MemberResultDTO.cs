namespace Survey.WebService.Models.DTOs
{
    public class MemberResultDTO
    {
        public SurveyModel Survey { get; set; }
        public AnswerModel Answer { get; set; }
        public MemberModel Member { get; set; }
    }
}
