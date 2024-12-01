using GDGHackathon.BLL.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGHackathon.BLL.Services.Interface
{
    public interface IUserService
    {
       Task<UserDto> LoginAsync(LoginDto loginDto);
       Task<UserDto> RegisterAsync(RegisterDto registerDto);

        Task<bool> CheckEmailExistAsync(string email);
    }
}
