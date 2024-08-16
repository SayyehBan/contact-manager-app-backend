using contact_manager_app.Model.Entities;
using contact_manager_app.Service.Repository;
using Microsoft.AspNetCore.Mvc;

namespace contact_manager_app.Controllers;

[Route("api/[controller]/[Action]")]
[ApiController]
public class GroupsController : ControllerBase
{
    private readonly RGroups rGroups;

    public GroupsController(RGroups rGroups)
    {
        this.rGroups = rGroups;
    }

    [HttpGet]
    public async Task<IEnumerable<VMGroup>> GetGroupsAsync()
    {
        return await rGroups.GetGroupsAsync();  
    }
}
