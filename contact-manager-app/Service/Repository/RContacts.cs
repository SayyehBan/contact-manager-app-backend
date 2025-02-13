using contact_manager_app.Infrastructure.Contexts;
using contact_manager_app.Model.Entities;
using contact_manager_app.Service.Interface;
using Dapper;
using SayyehBanTools.Converter;
using System.Data;
using System.Data.SqlClient;
using contact_manager_app.ConfigureService.Exceptions;

namespace contact_manager_app.Service.Repository;

/// <summary>
/// پیاده‌سازی سرویس مدیریت مخاطبین
/// </summary>
public class RContacts : IContacts
{
    /// <summary>
    /// حذف مخاطب
    /// </summary>
    /// <param name="ContactID">شناسه مخاطب</param>
    /// <returns>اطلاعات مخاطب حذف شده</returns>
    public async Task<VMDeleteContact?> DeleteContact(int ContactID)
    {
        using (var connection = new SqlConnection(SqlServer.ConnectionString()))
        {
            var sql = "dbo.DeleteContact";
            var parameters = new { ContactID = ContactID };
            var result = await connection.QueryFirstAsync<VMDeleteContact>(sql, parameters, commandType: CommandType.StoredProcedure);
            if (result.Photo != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }

    /// <summary>
    /// یافتن مخاطب با شناسه
    /// </summary>
    /// <param name="ContactID">شناسه مخاطب</param>
    /// <returns>اطلاعات مخاطب</returns>
    public async Task<VMFindContactID?> FindContactID(int ContactID)
    {
        using (var connection = new SqlConnection(SqlServer.ConnectionString()))
        {
            var sql = "dbo.FindContactID";
            var parameters = new { ContactID = ContactID };
            var result = await connection.QueryFirstOrDefaultAsync<VMFindContactID>(sql, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
    }

    /// <summary>
    /// دریافت لیست تمام مخاطبین
    /// </summary>
    /// <returns>لیست مخاطبین</returns>
    public async Task<IEnumerable<VMGetContacts>> GetContactsAsync()
    {
        using (var connection = new SqlConnection(SqlServer.ConnectionString()))
        {
            var sql = "dbo.GetContacts";
            var groups = await connection.QueryAsync<VMGetContacts>(sql, commandType: System.Data.CommandType.StoredProcedure);
            return groups.ToList();
        }
    }

    /// <summary>
    /// درج مخاطب جدید
    /// </summary>
    /// <param name="contact">اطلاعات مخاطب جدید</param>
    /// <returns>اطلاعات مخاطب ثبت شده</returns>
    public async Task<VMFindContactID> InsertContacts(VMInsertContact contact)
    {
        using (var con = new SqlConnection(SqlServer.ConnectionString()))
        {
            var sql = "InsertContact";

            await con.OpenAsync();
            var result = await con.QuerySingleAsync<VMFindContactID>(sql, new
            {
                FirstName = StringExtensions.CleanString(contact.FirstName ?? ""),
                LastName = StringExtensions.CleanString(contact.LastName ?? ""),
                Photo = StringExtensions.CleanString(contact.Photo ?? ""),
                Mobile = StringExtensions.CleanString(contact.Mobile ?? ""),
                Email = StringExtensions.CleanString(contact.Email ?? ""),
                JobID = contact.JobID,
                GroupID = contact.GroupID
            }, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }
    }

    /// <summary>
    /// به‌روزرسانی مخاطب
    /// </summary>
    /// <param name="contact">اطلاعات به‌روز شده مخاطب</param>
    /// <returns>اطلاعات مخاطب به‌روز شده</returns>
    public async Task<VMFindContactID> UpdateContact(VMUpdateContact contact)
    {
        using (var con = new SqlConnection(SqlServer.ConnectionString()))
        {
            var sql = "dbo.UpdateContact";
            await con.OpenAsync();
            var result = await con.QuerySingleAsync<VMFindContactID>(sql, new
            {
                ContactID = contact.ContactID,
                FirstName = StringExtensions.CleanString(contact.FirstName ?? ""),
                LastName = StringExtensions.CleanString(contact.LastName ?? ""),
                Photo = StringExtensions.CleanString(contact.Photo ?? ""),
                Mobile = StringExtensions.CleanString(contact.Mobile ?? ""),
                Email = StringExtensions.CleanString(contact.Email ?? ""),
                JobID = contact.JobID,
                GroupID = contact.GroupID
            }, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
