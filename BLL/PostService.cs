using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PostService : PostInterface
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PostModel>> GetAllPosts()
        {
            return await _context.Posts.Include(p => p.user).ToListAsync();
        }

        public async Task<PostModel?> GetPostById(int id)
        {
            return await _context.Posts.Include(p => p.user).FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<PostModel?> AddPost(PostModel postModel)
        {
            await _context.Posts.AddAsync(postModel);
            await _context.SaveChangesAsync();
            return postModel;
        }

        public async Task<PostModel?> UpdatePost(int id, PostModel postModel)
        {
            var existingPost = await _context.Posts.FindAsync(id);
            if (existingPost == null)
            {
                return null;
            }

            existingPost.title = postModel.title;
            existingPost.content = postModel.content;
            existingPost.readingTime = postModel.readingTime;
            existingPost.photo = postModel.photo;
            existingPost.userId = postModel.userId;

            _context.Posts.Update(existingPost);
            await _context.SaveChangesAsync();
            return existingPost;
        }

        public async Task<bool> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return false;
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
