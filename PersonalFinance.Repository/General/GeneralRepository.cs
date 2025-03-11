using Microsoft.EntityFrameworkCore;
using PersonalFinance.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Repository.General
{
   public class GeneralRepository<T> (ApplicationDbContext db) : IGeneralRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db = db;

        public async Task<T?> Get(Expression<Func<T, bool>> filter)
        {
           IQueryable<T> query = _db.Set<T>();
            query = query.Where(filter);
            return await query.SingleOrDefaultAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _db.Set<T>();
            if (filter == null)
            {
                return await query.ToListAsync(); 
            }

            query = query.Where(filter);
            return await query.ToListAsync();
        }
        public async Task<T> Add(T entity)
        {
            _db.Set<T>().Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task Delete(T entity)
        {
             _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<T> enteties)
        {
            _db.Set<T>().RemoveRange(enteties);
            await _db.SaveChangesAsync();
        }

        public void Detach()
        {
            _db.ChangeTracker.Clear();
        }

     
    }
}
