using ScheduleIS.Core.Models;
using ScheduleIS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleIS.Application.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<List<Group>> GetAllGroup()
        {
            return await _groupRepository.Get();
        }

        public async Task<Guid> CreateGroup(Group group)
        {
            return await _groupRepository.Create(group);
        }

        public async Task<Guid> UpdateGroup(Guid id, string name)
        {
            return await _groupRepository.Update(id, name);
        }

        public async Task<Guid> DeleteGroup(Guid id)
        {
            return await _groupRepository.Delete(id);
        }
    }
}
