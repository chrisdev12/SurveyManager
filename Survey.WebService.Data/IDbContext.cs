using System;

namespace Survey.WebService.DataAccess
{
    public interface IDbContext<TConnection> where TConnection : class
    {
        TConnection CreateConnection();
    }
}
