using GDGHackathon.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGHackathon.BLL.Services.Interface
{
    public interface ITokenService
    {
       Task<string> CreateTokenAsync(ApplicationUser user,UserManager<ApplicationUser> userManager);

    }
}
