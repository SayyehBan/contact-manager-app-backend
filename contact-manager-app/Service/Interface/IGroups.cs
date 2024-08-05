using contact_manager_app.Service.Model;
using System.Text.RegularExpressions;

namespace contact_manager_app.Service.Interface;

public interface IGroups
{
   Task<IEnumerable<VMGroup>> GetGroupsAsync();
}
