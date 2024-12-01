using GDGHackathon.BLL.Dtos.Auth;
using GDGHackathon.BLL.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GDGHackathon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUserService userService;

        public AccountsController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Logins(LoginDto loginDto)
        {

            if (loginDto == null)
            {
                return BadRequest(new { Message = "Login data is required." });
            }

            var user = await userService.LoginAsync(loginDto);

            if (user == null)
            {
                return Unauthorized(new { Message = "Invalid username or password." });
            }

            return Ok(user);
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (registerDto == null)
            {
                return BadRequest(new { Message = "Register data is required." });
            }

           
                // Check if the email already exists
                var emailExists = await userService.CheckEmailExistAsync(registerDto.Email);
                if (emailExists)
                {
                    return BadRequest(new { Message = "Email is already in use." });
                }

                var user = await userService.RegisterAsync(registerDto);

                if (user == null)
                {
                    return BadRequest(new { Message = "Invalid registration." });
                }

                return Ok(new { Message = "Registration successful.", User = user });
            
           
        }

    }
}

