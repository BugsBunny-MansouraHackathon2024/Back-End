using GDGHackathon.BLL.Repository.Interfaces;
using GDGHackathon.DAL.Data;
using GDGHackathon.DAL.Repository;
using GDGHackathon.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGHackathon.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        
             private readonly ApplicationDbContext _context;

        // A Hashtable to store instantiated repositories by entity type.
            private Hashtable _repositories;


            public UnitOfWork(ApplicationDbContext context)
            {
                _context = context;
                _repositories = new Hashtable(); // Initializes the repository container.
            }


        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (!_repositories.ContainsKey(typeof(TEntity).Name))
            {
                // Create a new repository instance for the entity type.
                var repository = new GenericRepository<TEntity>(_context);

                // Store the repository instance in the Hashtable using the entity type's name as the key.
                _repositories.Add(typeof(TEntity).Name, repository);
            }

            // Retrieve and return the repository from the Hashtable.
            return _repositories[typeof(TEntity).Name] as IGenericRepository<TEntity>;
        }
    }
}
