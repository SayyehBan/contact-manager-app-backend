using contact_manager_app.Service.Context;
using contact_manager_app.Service.Interface;
using contact_manager_app.Service.Model;
using Dapper;
using System.Data.SqlClient;

namespace contact_manager_app.Service.Repository;

public class RJobs : IJobs
{
    public async Task<IEnumerable<VMJobs>> GetJobAsync()
    {
        using (var connection = new SqlConnection(SqlServer.ConnectionString()))
        {
            var sql = "dbo.GetJob";
            var groups = await connection.QueryAsync<VMJobs>(sql, commandType: System.Data.CommandType.StoredProcedure);
            return groups.ToList();
        }
    }
}
