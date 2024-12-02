using GDGHackathon.DAL.Data;
using GDGHackathon.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGHackathon.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public IProductRepository Product {  get; set; }

        public IUserRepository UserApp { get; set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            Product=new ProductRepository(context);
            UserApp=new UserRepository(context);
            
        }
        
    }
}
