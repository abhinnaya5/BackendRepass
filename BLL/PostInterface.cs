using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface PostInterface
    {
        Task<IEnumerable<PostModel>> GetAllPosts();
        Task<PostModel?> GetPostById(int id);
        Task<PostModel?> AddPost(PostModel postModel);
        Task<PostModel?> UpdatePost(int id, PostModel postModel);
        Task<bool> DeletePost(int id);
    }
}
