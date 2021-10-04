using Survey.WebService.Models;
using System.Threading.Tasks;

namespace Survey.WebService.Services
{
    public interface IGeneralSurveyService
    {
        public Task<OperationStatusEnum> UpdateOrCreate(SurveyModel survey);
    }
}
