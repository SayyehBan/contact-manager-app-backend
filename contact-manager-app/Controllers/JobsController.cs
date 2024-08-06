using contact_manager_app.Service.Model;
using contact_manager_app.Service.Repository;
using Microsoft.AspNetCore.Mvc;

namespace contact_manager_app.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class JobsController : ControllerBase
{
    private readonly RJobs rJobs;

    public JobsController(RJobs rJobs)
    {
        this.rJobs = rJobs;
    }
    [HttpGet]
    public async Task<IEnumerable<VMJobs>> GetJobsAsync()
    {
        return await rJobs.GetJobAsync();
    }
}
