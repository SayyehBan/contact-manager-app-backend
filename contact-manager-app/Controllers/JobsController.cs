using contact_manager_app.Model.Entities;
using contact_manager_app.Service.Repository;
using Microsoft.AspNetCore.Mvc;

namespace contact_manager_app.Controllers;

/// <summary>
/// کنترلر برای مدیریت شغل‌ها
/// </summary>
[Route("api/[controller]/[action]")]
[ApiController]
public class JobsController : ControllerBase
{
    private readonly RJobs rJobs;

    /// <summary>
    /// نمونه سازی جدید از کنترلر شغل‌ها
    /// </summary>
    /// <param name="rJobs">مخزن شغل‌ها</param>
    public JobsController(RJobs rJobs)
    {
        this.rJobs = rJobs;
    }

    /// <summary>
    /// دریافت تمام شغل‌ها
    /// </summary>
    /// <returns>مجموعه‌ای از شغل‌ها</returns>
    [HttpGet]
    public async Task<IEnumerable<VMJobs>> GetJobsAsync()
    {
        return await rJobs.GetJobAsync();
    }
}
