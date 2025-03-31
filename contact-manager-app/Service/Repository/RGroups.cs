using contact_manager_app.Infrastructure.Contexts;
using contact_manager_app.Model.Entities;
using contact_manager_app.Service.Interface;
using Dapper;
using Microsoft.Data.SqlClient;

namespace contact_manager_app.Service.Repository;

/// <summary>
/// پیاده‌سازی سرویس مدیریت گروه‌های مخاطبین
/// </summary>
public class RGroups : IGroups
{

    /// <summary>
    /// دریافت لیست تمام گروه‌ها
    /// </summary>
    /// <returns>لیست گروه‌های مخاطبین</returns>
    public async Task<IEnumerable<VMGroup>> GetGroupsAsync()
    {
        using (var connection = new SqlConnection(SqlServer.ConnectionString()))
        {
            var sql = "dbo.GetGroups";
            var groups = await connection.QueryAsync<VMGroup>(sql, commandType: System.Data.CommandType.StoredProcedure);
            return groups.ToList();
        }
    }

}
