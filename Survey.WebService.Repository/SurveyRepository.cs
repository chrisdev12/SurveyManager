using Dapper;
using Survey.WebService.DataAccess.DbContexts.Survey;
using Survey.WebService.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.WebService.Repository
{
    public class SurveyRepository : IRepository<SurveyModel>
    {
        private readonly ISurveyContext _dbContext;
        private readonly string getSurveySP = "ws.sp_WS_GetSurveyById";
        private readonly string updateSurveySP = "ws.sp_WS_UpdateSurveyById";
        private readonly string insertSurveySP = "ws.sp_WS_InsertSurvey";
        public SurveyRepository(ISurveyContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<SurveyModel> Get(string id)
        {
            var parameters = new
            {
                SurveyId = id
            };
            using var connection = _dbContext.CreateConnection();
            var surveyFound = await connection.QueryAsync<SurveyModel>(getSurveySP, parameters, commandType: CommandType.StoredProcedure);

            return surveyFound.ToList().FirstOrDefault(); ;
        }

        public Task<List<SurveyModel>> GetAll(string id = null)
        {
            throw new System.NotImplementedException();
        }

        public async Task<SurveyModel> Insert(SurveyModel survey)
        {
            var parameters = new
            {
                SurveyId = survey.Id,
                Description = survey.Description
            };
            using var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(insertSurveySP, parameters, commandType: CommandType.StoredProcedure);

            return survey;
        }

        public async Task<SurveyModel> Update(SurveyModel survey)
        {
            var parameters = new
            {
                SurveyId = survey.Id,
                Description = survey.Description
            };

            using var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(updateSurveySP, parameters, commandType: CommandType.StoredProcedure);

            return survey;
        }
    }
}
