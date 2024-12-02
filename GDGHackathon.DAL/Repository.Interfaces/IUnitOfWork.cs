using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGHackathon.DAL.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        public IProductRepository Product { get; }
        public IUserRepository UserApp { get; }
       
    }
}
