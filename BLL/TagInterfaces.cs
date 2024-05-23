using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface TagInterfaces
    {
        Task<IEnumerable<TagModel>> GetAllTags();
        Task<TagModel?> GetTagById(int id);
        Task<TagModel?> AddTag(TagModel tagModel);
        Task<TagModel?> UpdateTag(int id, TagModel tagModel);
        Task<bool> DeleteTag(int id);
    }
}
