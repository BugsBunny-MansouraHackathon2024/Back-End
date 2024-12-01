using GDGHackathon.BLL.Repository.Interfaces;
using GDGHackathon.DAL.Data;
using GDGHackathon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGHackathon.DAL.Repository
{
    public class ProductRepository:GenericRepository<Product>
    {
        private readonly ApplicationDbContext db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }
    }
}
