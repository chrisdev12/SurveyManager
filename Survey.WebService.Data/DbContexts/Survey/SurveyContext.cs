using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Survey.WebService.DataAccess.DbContexts.Survey
{
    public class SurveyContext :  ISurveyContext
    {
        private readonly string _connectionString;
        public SurveyContext(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("K8Survey");
        }

        IDbConnection IDbContext<IDbConnection>.CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
