using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PostModel
    {
        public int? id { set; get; }

        [Required]
        public string title { set; get; } = string.Empty;

        [Required]
        public string content { set; get; } = string.Empty;


        [Required]
        public int readingTime { set; get; } = 0;

        [Required]
        public string photo { set; get; } = string.Empty;

        public int? userId { set; get; }
        
        [ForeignKey("userId")]
        public UserModel? user { set; get; }
    }
}
