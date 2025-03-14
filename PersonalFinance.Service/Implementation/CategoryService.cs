using PersonalFinance.Domain.Models;
using PersonalFinance.Repository.General;
using PersonalFinance.Repository.Implementation;
using PersonalFinance.Repository.UnifOfWorkRepository;
using PersonalFinance.Service.General;
using PersonalFinance.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.Implementation
{
    public class CategoryService : GeneralService<Category>, ICategoryService
    {
        private readonly IGeneralRepository<Category> _repository;

        public CategoryService(IUnitOfWorkRepository unitOfWork) : base(unitOfWork)
        {
            _repository = unitOfWork.GetRepository<Category>();
        }

        public async Task<Category> Update(int Id, Category category)
        {
            var obj = await _repository.Get(u => u.Id == Id);

            obj.categoryName = category.categoryName;
            obj.TransactionList = category.TransactionList;
            obj.AccountUserBudgetList = category.AccountUserBudgetList;

            return await ((CategoryRepository)_repository).Update(obj);

        }
    }
}
