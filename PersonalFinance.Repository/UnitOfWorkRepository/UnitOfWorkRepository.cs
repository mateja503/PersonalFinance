using PersonalFinance.Domain.Identity;
using PersonalFinance.Domain.Identity.RoleManager;
using PersonalFinance.Domain.Models;
using PersonalFinance.Repository.Data;
using PersonalFinance.Repository.General;
using PersonalFinance.Repository.Implementation;
using PersonalFinance.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Repository.UnifOfWorkRepository
{
    public class UnitOfWorkRepository: IUnitOfWorkRepository
    {

        private readonly ApplicationDbContext _db;
        
        public IAccountUserBudgetRepository AccountUserBudgetRepository { get; private set; }

        public IBudgetRepository BudgetRepository { get; private set; }

        public ICategoryRepository CategoryRepository { get; private set; }

        public IFinancialGoalsRepository FinancialGoalsRepository  { get; private set; }

        public INoteRepository NoteRepository { get; private set; }

        public ITransactionNotesRepository TransactionNotesRepository { get; private set; }

        public ITransactionRepository TransactionRepository { get; private set; }

        public IAccountUserFinancialGoalsRepository AccountUserFinancialGoalsRepository { get; private set; }

        public IAccountUserRepository AccountUserRepository { get; private set; }

        public IRoleRepository RoleRepository { get; private set; }

        public IAccountUserRoleRepository AccountUserRoleRepository { get; private set; }

        public UnitOfWorkRepository(ApplicationDbContext db)
        {
            _db = db;
            AccountUserBudgetRepository = new AccountUserBudgetRepository(_db);
            AccountUserFinancialGoalsRepository = new AccountUserFinancialGoalsRepository(_db);
            BudgetRepository = new BudgetRepository(_db);
            CategoryRepository = new CategoryRepository(_db);
            FinancialGoalsRepository = new FinancialGoalsRepository(_db);
            NoteRepository = new NoteRepository(_db);
            TransactionNotesRepository = new TransactionNotesRepository(_db);
            TransactionRepository = new TransactionRepository(_db);
            AccountUserRepository = new AccountUserRepository(_db);
            RoleRepository = new RoleRepository(_db);
            AccountUserRoleRepository = new AccountUserRoleRepository(_db);





        }

        public IGeneralRepository<T> GetRepository<T>() where T : class
        {
            if (typeof(T) == typeof(AccountUserBudget))
                return (IGeneralRepository<T>)AccountUserBudgetRepository;
            if (typeof(T) == typeof(Budget))
                return (IGeneralRepository<T>)BudgetRepository;
            if (typeof(T) == typeof(Category))
                return (IGeneralRepository<T>)CategoryRepository;
            if (typeof(T) == typeof(FinancialGoals))
                return (IGeneralRepository<T>)FinancialGoalsRepository;
            if (typeof(T) == typeof(Note))
                return (IGeneralRepository<T>)NoteRepository;
            if (typeof(T) == typeof(TransactionNotes))
                return (IGeneralRepository<T>)TransactionNotesRepository;
            if (typeof(T) == typeof(Transaction))
                return (IGeneralRepository<T>)TransactionRepository;
            if (typeof(T) == typeof(AccountUserFinancialGoals))
                return (IGeneralRepository<T>)AccountUserFinancialGoalsRepository;
            if (typeof(T) == typeof(AccountUser))
                return (IGeneralRepository<T>)AccountUserRepository;
            if (typeof(T) == typeof(Role))
                return (IGeneralRepository<T>)RoleRepository;
            if (typeof(T) == typeof(AccountUserRole))
                return (IGeneralRepository<T>)AccountUserRoleRepository;


            throw new NotImplementedException($"No repository found for type {typeof(T).Name}");
        }

    }
}
