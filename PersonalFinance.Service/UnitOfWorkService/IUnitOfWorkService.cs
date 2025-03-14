using PersonalFinance.Service.IdentityService;
using PersonalFinance.Service.IdentityService.RoleService;
using PersonalFinance.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.UnitOfWorkService
{
    public interface IUnitOfWorkService
    {

        IAccountUserBudgetService AccountUserBudgetService { get; }

        IAccountUserFinancialGoalsService AccountUserFinancialGoalsService { get; }

        IBudgetService BudgetService { get; }

        ICategoryService CategoryService { get; }

        IFinancialGoalsService FinancialGoalsService { get; }

        INoteService NoteService { get; }

        ITransactionNoteService TransactionNoteService {get;}

        ITransactionService TransactionService { get; }

        IAccountUserService AccountUserService { get; }

        IRoleService RoleService { get; }

        IAccountUserRoleService AccountUserRoleService { get; }
    }
}
