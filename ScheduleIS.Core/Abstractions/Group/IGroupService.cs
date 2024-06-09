using ScheduleIS.Core.Models;

namespace ScheduleIS.Core
{
    public interface IGroupService
    {
        Task<Guid> CreateGroup(Group group);
        Task<Guid> DeleteGroup(Guid id);
        Task<List<Group>> GetAllGroup();
        Task<Guid> UpdateGroup(Guid id, string name);
    }
}