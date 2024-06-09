using Microsoft.AspNetCore.Mvc;
using ScheduleIS.API.Contracts;
using ScheduleIS.Core.Models;
using ScheduleIS.Core;
using ScheduleIS.API.Contracts.Group;

namespace ScheduleIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController: ControllerBase
    {
        private readonly IGroupService _groupService;
        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }


        [HttpGet]
        public async Task<ActionResult<List<GroupResponse>>> GetGroup()
        {
            var group = await _groupService.GetAllGroup();

            var response = group.Select(b => new GroupResponse(b.Id, b.Name));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateGroup([FromBody] GroupRequest request)
        {
            var (group, error) = Group.Create(
                Guid.NewGuid(),
                request.name);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var groupId = await _groupService.CreateGroup(group);

            return Ok(groupId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateGroup(Guid id, [FromBody] GroupRequest request)
        {
            var groupId = await _groupService.UpdateGroup(id, request.name);

            return Ok(groupId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteGroup(Guid id)
        {
            return Ok(await _groupService.DeleteGroup(id));
        }

    }
}
