namespace contact_manager_app.Model.Entities;

/// <summary>
/// مدل نمایش گروه مخاطبین
/// </summary>
public class VMGroup
{
    /// <summary>
    /// شناسه گروه
    /// </summary>
    public int GroupID { get; set; }

    /// <summary>
    /// عنوان گروه
    /// </summary>
    public string? GroupTitle { get; set; }
}
