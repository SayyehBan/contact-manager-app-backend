using contact_manager_app.Model.Entities;
using contact_manager_app.Service.Repository;
using Microsoft.AspNetCore.Mvc;

namespace contact_manager_app.Controllers;

/// <summary>
/// کنترلر برای مدیریت گروه‌های مخاطبین
/// </summary>
[Route("api/[controller]/[Action]")]
[ApiController]
public class GroupsController : ControllerBase
{
    private readonly RGroups rGroups;

    /// <summary>
    /// نمونه سازی جدید از کنترلر گروه‌ها
    /// </summary>
    /// <param name="rGroups">مخزن گروه‌ها</param>
    public GroupsController(RGroups rGroups)
    {
        this.rGroups = rGroups;
    }

    /// <summary>
    /// دریافت تمام گروه‌های مخاطبین
    /// </summary>
    /// <returns>مجموعه‌ای از گروه‌های مخاطبین</returns>
    [HttpGet]
    public async Task<IEnumerable<VMGroup>> GetGroupsAsync()
    {
        return await rGroups.GetGroupsAsync();
    }
}
