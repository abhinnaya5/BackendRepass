using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly GroupService _groupService;

        public GroupController(GroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupModel>>> GetAll()
        {
            var groups = await _groupService.GetAllGroups();
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupModel>> Get(int id)
        {
            var group = await _groupService.GetGroupById(id);
            if (group == null)
            {
                return NotFound();
            }
            return Ok(group);
        }

        [HttpPost]
        public async Task<ActionResult<GroupModel>> Add(GroupModel groupModel)
        {
            var createdGroup = await _groupService.AddGroup(groupModel);
            return CreatedAtAction(nameof(Get), new { id = createdGroup.id }, createdGroup);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GroupModel>> Update(int id, GroupModel groupModel)
        {
            var updatedGroup = await _groupService.UpdateGroup(id, groupModel);
            if (updatedGroup == null)
            {
                return NotFound();
            }
            return Ok(updatedGroup);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _groupService.DeleteGroup(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
