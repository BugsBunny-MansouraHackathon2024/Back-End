using GDGHackathon.BLL.Dtos.Auth;
using GDGHackathon.BLL.Services.Interface;
using GDGHackathon.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGHackathon.BLL.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ITokenService tokenService;

        public UserService(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,ITokenService tokenService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
        }

       

        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
           var user = await userManager.FindByEmailAsync(loginDto.Email);
            if (user is null) return null;
            
          var result= await  signInManager.CheckPasswordSignInAsync(user, loginDto.Password,false);

            if (!result.Succeeded) return null;

            return new UserDto()
            {
                UserName = user.UserName,
                Email=user.Email,
                Token=await tokenService.CreateTokenAsync(user,userManager)
            }; 
        }

        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            if (await CheckEmailExistAsync(registerDto.Email)) return null;

            // Validate the role input
            var validRoles = new[] { "Farmer", "Wholesaler" };
            if (!validRoles.Contains(registerDto.Role))
                throw new ArgumentException("Invalid role specified. Please choose either 'Farmer' or 'Wholesaler'.");

            var user = new ApplicationUser() {
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                PhoneNumber = registerDto.PhoneNumber,
                Address = registerDto.Address,
                Role=registerDto.Role,
            };

           var result=await userManager.CreateAsync(user, registerDto.Password);
            if(!result.Succeeded) return null;

            return new UserDto()
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                Token = await tokenService.CreateTokenAsync(user, userManager)
            };
        }
        public async Task<bool> CheckEmailExistAsync(string email)
        {
            return await userManager.FindByEmailAsync(email) is not null;
        }
    }
}
