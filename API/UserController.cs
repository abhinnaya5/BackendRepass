using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> Get(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserModel>> Login(UserModel userModel)
        {
            var user = await _userService.LoginUser(userModel);
            if (user == null)
            {
                return Unauthorized("Invalid FullName or Gender");
            }
            return Ok(user);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutUser();
            return NoContent();
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserModel>> Register(UserModel userModel)
        {
            try
            {
                var user = await _userService.RegisterUser(userModel);
                return CreatedAtAction(nameof(Get), new { id = user.id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Update(int id, UserModel userModel)
        {
            var updatedUser = await _userService.UpdateUserById(id, userModel);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }
    }
}