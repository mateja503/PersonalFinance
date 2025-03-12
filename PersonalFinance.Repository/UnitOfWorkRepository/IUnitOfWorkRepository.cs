using PersonalFinance.Repository.General;
using PersonalFinance.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Repository.UnifOfWorkRepository
{
    public interface IUnitOfWorkRepository
    {

        IGeneralRepository<T> GetRepository<T>() where T : class;

        IAccountUserBudgetRepository AccountUserBudgetRepository { get; }

        IAccountUserFinancialGoalsRepository AccountUserFinancialGoalsRepository { get; }

        IBudgetRepository BudgetRepository { get; }

        ICategoryRepository CategoryRepository { get;  }

        IFinancialGoalsRepository FinancialGoalsRepository { get; }

        INoteRepository NoteRepository { get; }

        ITransactionNotesRepository TransactionNotesRepository { get; }

        ITransactionRepository TransactionRepository { get;  }
    }
}
