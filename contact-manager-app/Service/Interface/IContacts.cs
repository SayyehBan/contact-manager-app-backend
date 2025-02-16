using contact_manager_app.Model.Entities;

namespace contact_manager_app.Service.Interface;

/// <summary>
/// واسط سرویس مدیریت مخاطبین
/// </summary>
public interface IContacts
{
    /// <summary>
    /// دریافت لیست تمام مخاطبین
    /// </summary>
    /// <returns>لیست مخاطبین</returns>
    Task<IEnumerable<VMGetContacts>> GetContactsAsync();
    /// <summary>
    /// جستجوی مخاطب بر اساس نام و نام خانوادگی
    /// </summary>
    /// <param name="FullName"></param>
    /// <returns></returns>
    Task<IEnumerable<VMGetContacts>> GetSearchContactsAsync(string FullName);

    /// <summary>
    /// یافتن مخاطب با شناسه
    /// </summary>
    /// <param name="ContactID">شناسه مخاطب</param>
    /// <returns>اطلاعات مخاطب</returns>
    Task<VMFindContactID?> FindContactID(int ContactID);

    /// <summary>
    /// درج مخاطب جدید
    /// </summary>
    /// <param name="contact">اطلاعات مخاطب جدید</param>
    /// <returns>اطلاعات مخاطب ثبت شده</returns>
    Task<VMFindContactID> InsertContacts(VMInsertContact contact);

    /// <summary>
    /// به‌روزرسانی مخاطب
    /// </summary>
    /// <param name="contact">اطلاعات به‌روز شده مخاطب</param>
    /// <returns>اطلاعات مخاطب به‌روز شده</returns>
    Task<VMFindContactID> UpdateContact(VMUpdateContact contact);

    /// <summary>
    /// حذف مخاطب
    /// </summary>
    /// <param name="ContactID">شناسه مخاطب</param>
    /// <returns>اطلاعات مخاطب حذف شده</returns>
    Task<int> DeleteContact(int ContactID);
}
