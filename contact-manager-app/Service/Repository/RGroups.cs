using contact_manager_app.Infrastructure.Contexts;
using contact_manager_app.Model.Entities;
using contact_manager_app.Service.Interface;
using Dapper;
using System.Data.SqlClient;

namespace contact_manager_app.Service.Repository;

public class RGroups : IGroups
{

    public async Task<IEnumerable<VMGroup>> GetGroupsAsync()
    {
        using (var connection = new SqlConnection(SqlServer.ConnectionString()))
        {
            var sql = "dbo.GetGroups";
            var groups = await connection.QueryAsync<VMGroup>(sql,commandType:System.Data.CommandType.StoredProcedure);
            return groups.ToList();
        }
    }

}
