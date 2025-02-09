namespace contact_manager_app.Model.Entities;

/// <summary>
/// مدل نمایش شغل‌ها
/// </summary>
public class VMJobs
{
    /// <summary>
    /// شناسه شغل
    /// </summary>
    public int JobID { get; set; }

    /// <summary>
    /// عنوان شغل
    /// </summary>
    public string? JobTitle { get; set; }
}
