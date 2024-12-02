using GDGHackathon.BLL.Repository.Interfaces;
using GDGHackathon.DAL.Data;
using GDGHackathon.DAL.Entities;
using GDGHackathon.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GDGHackathon.DAL.Repository
{
    public class ProductRepository : GenericRepository<Product,int>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
