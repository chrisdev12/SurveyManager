using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Survey.WebService.DataAccess.DbContexts.Survey
{
    public class SurveyContext :  ISurveyContext
    {
        private readonly string _connectionString;
        private readonly string _connectionName = "SurveyDefaultConnection";
        public SurveyContext(IConfiguration config)
        {
            _connectionString = config.GetConnectionString(_connectionName);
        }

        IDbConnection IDbContext<IDbConnection>.CreateConnection()
        {
            try
            {
                return new SqlConnection(_connectionString);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
