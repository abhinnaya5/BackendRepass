using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CommentService : CommentInterface
    {
        private readonly ApplicationDbContext _context;
        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CommentModel>> GetAllComments()
        {
            return await _context.Comments.ToListAsync();
        }
        public async Task<CommentModel?> GetCommentById(int id)
        {
            return await _context.Comments.FindAsync(id);
        }
        public async Task<CommentModel?> AddComment(CommentModel commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }
        public async Task<CommentModel?> UpdateComment(int id, CommentModel commentModel)
        {
            var existingComment = await _context.Comments.FindAsync(id);
            if (existingComment == null)
            {
                return null;
            }

            existingComment.content = commentModel.content;
            existingComment.postId = commentModel.postId;
            existingComment.userId = commentModel.userId;
            existingComment.subCommentId = commentModel.subCommentId;

            _context.Comments.Update(existingComment);
            await _context.SaveChangesAsync();
            return existingComment;
        }
        public async Task<bool> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return false;
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
