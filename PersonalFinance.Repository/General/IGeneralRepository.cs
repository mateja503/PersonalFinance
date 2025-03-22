using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Repository.General
{
    public interface IGeneralRepository<T> where T : class
    {
        public Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null);

        public Task<T> Get(Expression<Func<T, bool>> filter);

        public Task<T> Add(T entity);


        public Task<T> Delete(Expression<Func<T, bool>> filter);

        public Task<List<T>> DeleteRange(IEnumerable<T> enteties);

        public void Detach();

        //public void Attach();
    }
}
