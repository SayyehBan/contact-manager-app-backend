using contact_manager_app.Service.Context;
using contact_manager_app.Service.Interface;
using contact_manager_app.Service.Model;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace contact_manager_app.Service.Repository;

public class RContacts : IContacts
{
    public async Task<IEnumerable<VMGetContacts>> GetContactsAsync()
    {
        using (var connection = new SqlConnection(SqlServer.ConnectionString()))
        {
            var sql = "dbo.GetContacts";
            var groups = await connection.QueryAsync<VMGetContacts>(sql, commandType: System.Data.CommandType.StoredProcedure);
            return groups.ToList();
        }
    }

    public async Task<int> InsertContacts(VMInsertContacts contact)
    {
        using (var con = new SqlConnection(SqlServer.ConnectionString()))
        {
            var sql = "InsertContact";

            await con.OpenAsync();
            var result = await con.QuerySingleAsync<int>(sql, new
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Photo = contact.Photo,
                Mobile = contact.Mobile,
                Email = contact.Email,
                JobID = contact.JobID,
                GroupID = contact.GroupID
            }, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }
    }
}
