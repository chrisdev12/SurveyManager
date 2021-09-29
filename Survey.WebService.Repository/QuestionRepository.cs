using Dapper;
using Survey.WebService.DataAccess.DbContexts.Survey;
using Survey.WebService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.WebService.Repository
{
    public class QuestionRepository : IRepository<QuestionModel>
    {
        private readonly ISurveyContext _dbContext;
        private readonly string getSurveyQuestions = "ws.sp_WS_GetSurveyQuestions";
        private readonly string updateSurveyQuestion = "ws.sp_WS_UpdateQuestion";
        private readonly string insertSurveyQuestion = "ws.sp_WS_InsertQuestion";
        public QuestionRepository(ISurveyContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<QuestionModel> Get(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<QuestionModel>> GetAll(string id)
        {
            var parameters = new
            {
                SurveyId = id
            };
            using var connection = _dbContext.CreateConnection();
            var questionsFound = await connection.QueryAsync<QuestionModel>(getSurveyQuestions, parameters, commandType: CommandType.StoredProcedure);

            return questionsFound.ToList();
        }

        public async Task<QuestionModel> Insert(QuestionModel question)
        {
            var parameters = new
            {
                QuestionId = question.Id,
                SurveyId = question.SurveyId,
                Description = question.Description
            };
            using var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(insertSurveyQuestion, parameters, commandType: CommandType.StoredProcedure);

            return question;
        }

        public async Task<QuestionModel> Update(QuestionModel question)
        {
            var parameters = new
            {
                QuestionId = question.Id,
                SurveyId = question.SurveyId,
                Description = question.Description
            };

            using var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(updateSurveyQuestion, parameters, commandType: CommandType.StoredProcedure);

            return question;
        }
    }
}
