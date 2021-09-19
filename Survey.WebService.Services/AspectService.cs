using Survey.WebService.Repository;

namespace Survey.WebService.Services
{
    public class AspectService : IAspectService
    {
        private readonly IAspectRepository _aspectRepository;
        public AspectService(IAspectRepository aspectRepository)
        {
            this._aspectRepository = aspectRepository;
        }
        public string GetAll()
        {
            return "working service";
        }
    }
}
