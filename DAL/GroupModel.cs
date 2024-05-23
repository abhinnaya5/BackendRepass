using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GroupModel
    {
        public int id { get; set; } = 0;

        [Required]
        public string name { get; set; } = string.Empty;

        [Required]
        public string description { get; set; } = string.Empty;

        public List<PostModel> posts { get; set; } = new List<PostModel>();
    }
}
