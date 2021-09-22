using Survey.WebService.Models.DTOs;
using System.Threading.Tasks;

namespace Survey.WebService.Services
{
    public interface IGeneralSurveyService
    {
        public Task<GeneralSurveyResponseDTO> BusinessRegistration(GeneralSurveyRequestDTO aspectRequest);
    }
}
