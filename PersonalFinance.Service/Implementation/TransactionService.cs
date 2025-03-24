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
    public class TransactionService : GeneralService<Transaction>, ITransactionService
    {
        private readonly IGeneralRepository<Transaction> _repository;
        private readonly IGeneralRepository<Category> _repositoryCategory;

        public TransactionService(IUnitOfWorkRepository unitOfWork) : base(unitOfWork)
        {
            _repository = unitOfWork.GetRepository<Transaction>();
            _repositoryCategory = unitOfWork.GetRepository<Category>();
        }

        public async Task<Transaction> GetTransaction(int Id)
        {
            var transaction = await _repository.Get(u => u.Id == Id);
            _ = transaction.Category;
            _repository.Detach();
            return transaction;
        }

        public async Task<Transaction> Update(int Id, Transaction transaction)
        {
            var obj = await _repository.Get(u => u.Id == Id);

            obj.amount = transaction.amount;
            obj.dateTime = transaction.dateTime;
            obj.TransactionNoteList = transaction.TransactionNoteList;
            obj.TransactionType = transaction.TransactionType;
            obj.CategoryId = transaction.CategoryId;

            return await ((TransactionRepository)_repository).Update(obj);
        }
    }
}
