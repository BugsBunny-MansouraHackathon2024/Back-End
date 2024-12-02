using GDGHackathon.DAL.Data;
using GDGHackathon.DAL.Entities.Identity;
using GDGHackathon.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGHackathon.DAL.Repository
{
    public class UserRepository : GenericRepository<ApplicationUser,string>,IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
