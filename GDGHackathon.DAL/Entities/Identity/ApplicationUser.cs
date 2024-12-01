using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGHackathon.DAL.Entities.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public int UserID { get; set; }
        public string Role { get; set; }
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

      
    }
}
