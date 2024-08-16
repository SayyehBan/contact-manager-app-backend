using contact_manager_app.Model.Entities;

namespace contact_manager_app.Service.Interface;

public interface IGroups
{
   Task<IEnumerable<VMGroup>> GetGroupsAsync();
}
