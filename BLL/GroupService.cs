using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GroupService : GroupInterface
    {
        private readonly ApplicationDbContext _context;

        public GroupService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<GroupModel>> GetAllGroups()
        {
            return await _context.Groups.Include(g => g.posts).ToListAsync();
        }

        public async Task<GroupModel?> GetGroupById(int id)
        {
            return await _context.Groups.Include(g => g.posts).FirstOrDefaultAsync(g => g.id == id);
        }

        public async Task<GroupModel?> AddGroup(GroupModel groupModel)
        {
            await _context.Groups.AddAsync(groupModel);
            await _context.SaveChangesAsync();
            return groupModel;
        }

        public async Task<GroupModel?> UpdateGroup(int id, GroupModel groupModel)
        {
            var existingGroup = await _context.Groups.FindAsync(id);
            if (existingGroup == null)
            {
                return null;
            }

            existingGroup.name = groupModel.name;
            existingGroup.description = groupModel.description;
            existingGroup.posts = groupModel.posts;

            _context.Groups.Update(existingGroup);
            await _context.SaveChangesAsync();
            return existingGroup;
        }

        public async Task<bool> DeleteGroup(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group == null)
            {
                return false;
            }

            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
