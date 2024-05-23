using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TagService : TagInterfaces
    {
        private readonly ApplicationDbContext _context;

        public TagService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TagModel>> GetAllTags()
        {
            return await _context.Tags.ToListAsync();
        }
        public async Task<TagModel?> GetTagById(int id)
        {
            return await _context.Tags.FindAsync(id);
        }
        public async Task<TagModel?> AddTag(TagModel tagModel)
        {
            await _context.Tags.AddAsync(tagModel);
            await _context.SaveChangesAsync();
            return tagModel;
        }
        public async Task<TagModel?> UpdateTag(int id, TagModel tagModel)
        {
            var existingTag = await _context.Tags.FindAsync(id);
            if (existingTag == null)
            {
                return null;
            }

            existingTag.name = tagModel.name;
            _context.Tags.Update(existingTag);
            await _context.SaveChangesAsync();
            return existingTag;
        }
        public async Task<bool> DeleteTag(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null)
            {
                return false;
            }

            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
