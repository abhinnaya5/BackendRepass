using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface UserInterface
    {
        Task<UserModel?> RegisterUser(UserModel userModel);
        Task<UserModel?> LoginUser(UserModel userModel);
        Task<UserModel?> GetUserById(int id);
        Task<UserModel?> UpdateUserById(int id, UserModel userModel);
        Task LogoutUser();
    }
}
