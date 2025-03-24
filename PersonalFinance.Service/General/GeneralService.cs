using PersonalFinance.Repository.Data;
using PersonalFinance.Repository.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.General
{
    public class GeneralService<T,R>(R repository):
        IGeneralService<T> where T : class
        where R : IGeneralRepository<T>
    {
        private readonly R _repository = repository;
        public async Task<T> Get(Expression<Func<T, bool>> filter)
        {
            var obj = await _repository.Get(filter);
            _repository.Detach();
            return obj;
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            var obj = await _repository.GetAll(filter);
            _repository.Detach();
            return obj;
        }

        public async Task<T> Add(T entity)
        {
            var obj = await _repository.Add(entity);
            _repository.Detach();
            return obj;
        }

        public async Task<T> Delete(Expression<Func<T, bool>> filter)
        {
            var obj = await _repository.Delete(filter);
            _repository.Detach();
            return obj;
        }

        public async Task<List<T>> DeleteRange(IEnumerable<T> enteties)
        {
            var obj = await _repository.DeleteRange(enteties);
            _repository.Detach();
            return obj;
        }

        public void Detach()
        {
            _repository.Detach();
         
        }

     
    }
}
