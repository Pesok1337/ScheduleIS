﻿using ScheduleIS.Core.Models;

namespace ScheduleIS.Core
{
    public interface IGroupRepository
    {
        Task<Guid> Create(Group group);
        Task<Guid> Delete(Guid id);
        Task<List<Group>> Get();
        Task<Guid> Update(Guid id, string name);
    }
}