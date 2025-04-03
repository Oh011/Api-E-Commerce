﻿using Domain.Contracts;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {


        private readonly ApplicationDbContext _context;




        public GenericRepository(ApplicationDbContext context)
        {


            _context = context;
        }
        public async Task AddAsync(TEntity entity) => await _context.AddAsync(entity);

        public void Delete(TEntity entity) => _context.Remove(entity);
        public void Update(TEntity entity) => _context.Update(entity);


        public async Task<IEnumerable<TEntity>> GetAllAsync(bool AsNoTracking)
        {


            if (AsNoTracking)
            {


                return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
            }


            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetById(TKey id) => await _context.Set<TEntity>().FindAsync(id);

    }
}
