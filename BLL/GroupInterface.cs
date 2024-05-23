using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface GroupInterface
    {
        Task<IEnumerable<GroupModel>> GetAllGroups();
        Task<GroupModel?> GetGroupById(int id);
        Task<GroupModel?> AddGroup(GroupModel groupModel);
        Task<GroupModel?> UpdateGroup(int id, GroupModel groupModel);
        Task<bool> DeleteGroup(int id);
    }
}
