using Dapper;
using Survey.WebService.DataAccess.DbContexts.Survey;
using Survey.WebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.WebService.Repository
{
    public class QuestionRepository : IRepository<QuestionModel>
    {
        private readonly ISurveyContext _dbContext;
        public QuestionRepository(ISurveyContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<QuestionModel> Get(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<QuestionModel>> GetAll(string id = null)
        {
            var query = $"SELECT MS.QuestionId, MS.Description FROM Survey S INNER JOIN QuestionSurvey MS ON MS.SurveyId = S.SurveyId WHERE MS.SurveyId = '432423';";
            using var connection = _dbContext.CreateConnection();
            var questionsFound = await connection.QueryAsync<QuestionModel>(query);

            return questionsFound.ToList();
        }

        public Task<QuestionModel> Insert(QuestionModel register)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionModel> Update(QuestionModel id)
        {
            throw new NotImplementedException();
        }
    }
}
