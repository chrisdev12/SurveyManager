namespace Survey.WebService.Models.DTOs
{
    public class GeneralSurveyResponseDTO
    {
        public string SurveyId { get; set; }
        public string MemberNumber { get; set; }
        public string AdditionalMessage { get; set; }
        public SurveyActionsEnum ActionExecuted { get; set;}
    }
}
