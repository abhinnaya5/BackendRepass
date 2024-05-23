using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DAL
{
    public class UserModel
    {
        public enum EnumGender
        {
            [Description("Male")]
            Male,

            [Description("Female")]
            Female
        }
        public int? id { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [EnumDataType(typeof(EnumGender))]
        public string Gender { get; set; } = string.Empty;
    }
}
