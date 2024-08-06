﻿using contact_manager_app.Service.Model;

namespace contact_manager_app.Service.Interface;

public interface IGroups
{
   Task<IEnumerable<VMGroup>> GetGroupsAsync();
}
