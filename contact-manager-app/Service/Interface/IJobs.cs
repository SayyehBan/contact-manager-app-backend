using contact_manager_app.Model.Entities;

namespace contact_manager_app.Service.Interface;

/// <summary>
/// واسط سرویس مدیریت شغل‌ها
/// </summary>
public interface IJobs
{
    /// <summary>
    /// دریافت لیست تمام شغل‌ها
    /// </summary>
    /// <returns>لیست شغل‌ها</returns>
    Task<IEnumerable<VMJobs>> GetJobAsync();
}
