using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserService : UserInterface
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<UserModel?> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<UserModel?> LoginUser(UserModel userModel)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Gender == userModel.Gender && u.FullName == userModel.FullName);

            return user;
        }

        public Task LogoutUser()
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel?> RegisterUser(UserModel userModel)
        {
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<UserModel?> UpdateUserById(int id, UserModel updatedUser)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }

            user.FullName = updatedUser.FullName;
            user.BirthDate = updatedUser.BirthDate;
            user.Gender = updatedUser.Gender;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
