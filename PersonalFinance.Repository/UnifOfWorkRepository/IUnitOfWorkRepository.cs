using PersonalFinance.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Repository.UnifOfWorkRepository
{
    interface IUnitOfWorkRepository
    {
        IAccountUserBudgetRepository AccountUserBudgetRepository { get; }

        IAccountUserFinancialGoalsRepository AccountUserFinancialGoals { get; }

        IBudgetRepository BudgetRepository { get; }

        ICategoryRepository CategoryRepository { get;  }

        IFinancialGoalsRepository FinancialGoalsRepository { get; }

        INoteRepository NoteRepository { get; }

        ITransactionNotesRepository TransactionNotesRepository { get; }

        ITransactionRepository TransactionRepository { get;  }
    }
}
