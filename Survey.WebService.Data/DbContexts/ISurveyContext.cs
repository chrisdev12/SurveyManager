using System.Data;

namespace Survey.WebService.DataAccess.DbContexts.Survey
{
    public interface ISurveyContext : IDbContext<IDbConnection>
    {
    }
}
