using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CommentModel
    {
        public int Id { get; set; } = 0;
        public string content { get; set; } = string.Empty;
        public int postId { get; set; } = 0;
        public int userId { get; set; } = 0;
        public int subCommentId { get; set; } = 0;
    }
}
