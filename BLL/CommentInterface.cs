using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface CommentInterface
    {
        Task<IEnumerable<CommentModel>> GetAllComments();
        Task<CommentModel?> GetCommentById(int id);
        Task<CommentModel?> AddComment(CommentModel commentModel);
        Task<CommentModel?> UpdateComment(int id, CommentModel commentModel);
        Task<bool> DeleteComment(int id);
    }
}
