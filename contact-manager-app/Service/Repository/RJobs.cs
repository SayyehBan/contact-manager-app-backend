using contact_manager_app.Infrastructure.Contexts;
using contact_manager_app.Model.Entities;
using contact_manager_app.Service.Interface;
using Dapper;
using System.Data.SqlClient;

namespace contact_manager_app.Service.Repository;

/// <summary>
/// پیاده‌سازی سرویس مدیریت شغل‌ها
/// </summary>
public class RJobs : IJobs
{
    /// <summary>
    /// دریافت لیست تمام شغل‌ها
    /// </summary>
    /// <returns>لیست شغل‌ها</returns>
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
