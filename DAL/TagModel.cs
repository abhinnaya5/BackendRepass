using System;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class TagModel
    {
        
        public int? id { get; set; }

        [Required]
        public string name { get; set; } = string.Empty;
    }
}
