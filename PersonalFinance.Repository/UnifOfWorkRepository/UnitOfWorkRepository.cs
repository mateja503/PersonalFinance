using PersonalFinance.Domain.Models;
using PersonalFinance.Repository.Data;
using PersonalFinance.Repository.Implementation;
using PersonalFinance.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Repository.UnifOfWorkRepository
{
    public class UnitOfWorkRepositor: IUnitOfWorkRepository
    {

        private readonly ApplicationDbContext _db;

        

        public IAccountUserBudgetRepository AccountUserBudgetRepository { get; private set; }

        public IAccountUserFinancialGoalsRepository AccountUserFinancialGoals { get; private set; }

        public IBudgetRepository BudgetRepository { get; private set; }

        public ICategoryRepository CategoryRepository { get; private set; }

        public IFinancialGoalsRepository FinancialGoalsRepository  { get; private set; }

        public INoteRepository NoteRepository { get; private set; }

        public ITransactionNotesRepository TransactionNotesRepository { get; private set; }

        public ITransactionRepository TransactionRepository { get; private set; }

        public UnitOfWorkRepositor(ApplicationDbContext db)
        {
            _db = db;
            AccountUserBudgetRepository = new AccountUserBudgetRepository(_db);
            AccountUserFinancialGoals = new AccountUserFinancialGoalsRepository(_db);
            BudgetRepository = new BudgetRepository(_db);
            CategoryRepository = new CategoryRepository(_db);
            FinancialGoalsRepository = new FinancialGoalsRepository(_db);
            NoteRepository = new NoteRepository(_db);
            TransactionNotesRepository = new TransactionNotesRepository(_db);
            TransactionRepository = new TransactionRepository(_db);




        }
    }
}
