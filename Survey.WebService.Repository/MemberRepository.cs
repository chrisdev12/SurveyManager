using Dapper;
using Survey.WebService.DataAccess.DbContexts.Survey;
using Survey.WebService.Models.DTOs;
using System.Data;
using System.Threading.Tasks;

namespace Survey.WebService.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ISurveyContext _dbContext;
        private readonly string insertMemberSurveyResult = "sp_WS_InsertMemberSurveyResult";
        public MemberRepository(ISurveyContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string> Register(MemberResultDTO newResult)
        {
            var parameters = new
            {
                ContractNumber = newResult.Member.MemberNumber,
                Name = newResult.Member.MemberName,
                LastName = newResult.Member.MemberLastName,
                PhoneNumber = newResult.Member.PhoneNumber,
                AlternativephoneNumber = newResult.Member.PhoneNumber1,
                IpaNumber = newResult.Member.IPA,
                PcpName = newResult.Member.ProviderName,
                PcpNPINumber = newResult.Member.ProviderNPI,
                CallDate = newResult.Member.Calldate,
                Disposition = newResult.Member.Disposition,
                QuestionId = newResult.Answer.AnswerId,
                SurveyId = newResult.Survey.Id,
                AnswerDescription = newResult.Answer.Description,
                AnswerPhoneDigit = newResult.Answer.PhoneDigit
            };
            using var connection = _dbContext.CreateConnection();
            var result = await connection.ExecuteAsync(insertMemberSurveyResult, parameters, commandType: CommandType.StoredProcedure);

            return result.ToString();
        }
    }
}
