using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.General
{
    public interface IGeneralService<T> where T : class
    {

        public Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null);

        public Task<T> Get(Expression<Func<T, bool>> filter);

        public Task<T> Add(T entity);


        public Task<T> Delete(Expression<Func<T, bool>> filter);

        public Task<List<T>> DeleteRange(IEnumerable<T> enteties);

        public void Detach();
    }
}
