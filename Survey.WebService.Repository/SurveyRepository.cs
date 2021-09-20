using Dapper;
using Survey.WebService.DataAccess.DbContexts.Survey;
using Survey.WebService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Survey.WebService.Repository
{
    public class SurveyRepository : IRepository<SurveyModel>
    {
        private readonly ISurveyContext _dbContext;
        public SurveyRepository(ISurveyContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<SurveyModel> Get(string id)
        {
            using var connection = _dbContext.CreateConnection();
            SurveyModel surveyFound = await connection.QuerySingleAsync<SurveyModel>("SELECT * FROM Survey WHERE SurveyId = '432423';");

            return surveyFound;
        }

        public Task<List<SurveyModel>> GetAll(string id = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<SurveyModel> Insert(SurveyModel register)
        {
            throw new System.NotImplementedException();
        }

        public Task<SurveyModel> Update(SurveyModel id)
        {
            throw new System.NotImplementedException();
        }
    }
}
