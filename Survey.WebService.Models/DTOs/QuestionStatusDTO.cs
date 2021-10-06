namespace Survey.WebService.Models.DTOs
{
    public class QuestionStatusDTO
    {
        public string QuestionId { get; set; }
        public string Status { get; set; }

        public void SetStatus(OperationStatusEnum questionStatus)
        {
            Status = questionStatus.ToString();
        }
    }
}
