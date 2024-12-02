using GDGHackathon.BLL.Repository.Interfaces;
using GDGHackathon.DAL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGHackathon.DAL.Repository.Interfaces
{
    public interface IUserRepository:IGenericRepository<ApplicationUser,string>
    {
    }
}
