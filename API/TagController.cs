using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly TagInterfaces _tagService;

        public TagController(TagInterfaces tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagModel>>> GetAll()
        {
            var tags = await _tagService.GetAllTags();
            return Ok(tags);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TagModel>> Get(int id)
        {
            var tag = await _tagService.GetTagById(id);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(tag);
        }

        [HttpPost]
        public async Task<ActionResult<TagModel>> Add(TagModel tagModel)
        {
            var createdTag = await _tagService.AddTag(tagModel);
            return CreatedAtAction(nameof(Get), new { id = createdTag.id }, createdTag);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TagModel>> Update(int id, TagModel tagModel)
        {
            var updatedTag = await _tagService.UpdateTag(id, tagModel);
            if (updatedTag == null)
            {
                return NotFound();
            }
            return Ok(updatedTag);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tagService.DeleteTag(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
