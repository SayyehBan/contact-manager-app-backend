using contact_manager_app.Model.Entities;

namespace contact_manager_app.Service.Interface;

/// <summary>
/// واسط سرویس مدیریت گروه‌های مخاطبین
/// </summary>
public interface IGroups
{
   /// <summary>
   /// دریافت لیست تمام گروه‌ها
   /// </summary>
   /// <returns>لیست گروه‌های مخاطبین</returns>
   Task<IEnumerable<VMGroup>> GetGroupsAsync();
}
