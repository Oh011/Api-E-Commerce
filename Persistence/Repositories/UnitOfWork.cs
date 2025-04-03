using Domain.Contracts;
using Persistence.Data;
using System.Collections.Concurrent;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {


        private readonly ApplicationDbContext _context;



        private ConcurrentDictionary<string, Object> _repositories;


        //The key is typeof(TEntity).Name ( "Product" for Product entity).

        //The value is a repository instance.


        //        Key     : Value
        //------------------------
        //"Product" : new GenericRepository<Product, int>
        //"Order"   : new GenericRepository<Order, int>




        public UnitOfWork(ApplicationDbContext context)
        {

            _context = context;
            _repositories = new ConcurrentDictionary<string, object>();
            //_repositories = new(); //This is the  new syntax introduced in C# 9.0. I
        }

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {


            //Repositories:

            //Key : value --> Product : new GenericRepository<Product,int>


            return (IGenericRepository<TEntity, TKey>)_repositories.GetOrAdd(typeof(TEntity).Name, (_) => new GenericRepository<TEntity, TKey>(_context));
        }

        public async Task<int> SaveChangesAsync()
        {

            return await _context.SaveChangesAsync();
        }
    }
}

//Get name from Type:

//GetType().Name