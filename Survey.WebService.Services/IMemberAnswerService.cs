using Survey.WebService.Models.DTOs;
using System.Threading.Tasks;

namespace Survey.WebService.Services
{
    public interface IMemberAnswerService
    {
        public Task UpdateOrCreate(GeneralSurveyRequestDTO aspectRequest);
    }
}
