using contact_manager_app.Service.Context;
using contact_manager_app.Service.Interface;
using contact_manager_app.Service.Model;
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
