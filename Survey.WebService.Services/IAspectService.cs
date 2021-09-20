using Survey.WebService.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Survey.WebService.Services
{
    public interface IAspectService
    {
        public Task<List<AspectRequestDTO>> VerifySurveyExistence(AspectRequestDTO aspectRequest);
    }
}
