using Microsoft.EntityFrameworkCore;
using PersonalFinance.Repository.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            var result = await query.SingleOrDefaultAsync();
            Detach();
            return result;
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            try
            {
                IQueryable<T> query = _db.Set<T>();
                if (filter == null)
                {
                    var result = await query.ToListAsync();
                    Detach();
                    return result;
                }

                query = query.Where(filter);
                Detach();
                return await query.ToListAsync();
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                return [];
            }
            
        }
        public async Task<T> Add(T entity)
        {
            _db.Set<T>().Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<T> Delete(T entity)
        {
             _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> DeleteRange(IEnumerable<T> enteties)
        {
            _db.Set<T>().RemoveRange(enteties);
            await _db.SaveChangesAsync();
            return enteties.ToList();
        }

        public void Detach()
        {
            _db.ChangeTracker.Clear();
        }

     
    }
}
