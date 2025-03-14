using PersonalFinance.Repository.General;
using PersonalFinance.Repository.UnifOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.General
{
    public class GeneralService<T>(IUnitOfWorkRepository unitOfWork) : IGeneralService<T> where T : class
    {

        private readonly IGeneralRepository<T> _repository = unitOfWork.GetRepository<T>();

        public async Task<T> Get(Expression<Func<T, bool>> filter)
        {
            return await _repository.Get(filter);
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            return await _repository.GetAll(filter);
        }

        public async Task<T> Add(T entity)
        {
            return await _repository.Add(entity);
        }

        public async Task<T> Delete(Expression<Func<T, bool>> filter)
        {
            return await _repository.Delete(filter);
        }

        public async Task<List<T>> DeleteRange(IEnumerable<T> enteties)
        {
            return await _repository.DeleteRange(enteties);
        }

        public void Detach()
        {
            _repository.Detach();
        }

     
    }
}
