using PersonalFinance.Domain.Models;
using PersonalFinance.Repository.Data;
using PersonalFinance.Repository.General;
using PersonalFinance.Repository.Implementation;
using PersonalFinance.Repository.Interface;
using PersonalFinance.Service.General;
using PersonalFinance.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.Implementation
{
    public class CategoryService : GeneralService<Category,ICategoryRepository>, ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository, ApplicationDbContext db) : base(repository)
        {
            _repository = new CategoryRepository(db);
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
