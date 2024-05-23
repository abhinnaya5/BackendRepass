using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostInterface _postService;

        public PostController(PostInterface postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostModel>>> GetAll()
        {
            var posts = await _postService.GetAllPosts();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostModel>> Get(int id)
        {
            var post = await _postService.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<PostModel>> Add(PostModel postModel)
        {
            var createdPost = await _postService.AddPost(postModel);
            return CreatedAtAction(nameof(Get), new { id = createdPost.id }, createdPost);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PostModel>> Update(int id, PostModel postModel)
        {
            var updatedPost = await _postService.UpdatePost(id, postModel);
            if (updatedPost == null)
            {
                return NotFound();
            }
            return Ok(updatedPost);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postService.DeletePost(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
