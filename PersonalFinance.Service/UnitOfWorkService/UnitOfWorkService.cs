using PersonalFinance.Repository.UnifOfWorkRepository;
using PersonalFinance.Service.IdentityService;
using PersonalFinance.Service.IdentityService.RoleService;
using PersonalFinance.Service.Implementation;
using PersonalFinance.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.UnitOfWorkService
{
    public class UnitOfWorkService : IUnitOfWorkService
    {

        private readonly IUnitOfWorkRepository _unitOfWork;


        public IAccountUserBudgetService AccountUserBudgetService { get; private set; }

        public IAccountUserFinancialGoalsService AccountUserFinancialGoalsService { get; private set; }

        public IBudgetService BudgetService { get; private set; }

        public ICategoryService CategoryService { get; private set; }

        public IFinancialGoalsService FinancialGoalsService { get; private set; }

        public INoteService NoteService { get; private set; }

        public ITransactionNoteService TransactionNoteService { get; private set; }

        public ITransactionService TransactionService { get; private set; }

        public IAccountUserService AccountUserService { get; private set; }

        public IRoleService RoleService { get; private set; }

        public IAccountUserRoleService AccountUserRoleService { get; private set; }

        public UnitOfWorkService(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
            AccountUserBudgetService = new AccountUserBudgetService(_unitOfWork);
            AccountUserFinancialGoalsService = new AccountUserFinancialGoalsService(_unitOfWork);
            BudgetService = new BudgetService(_unitOfWork);
            CategoryService = new CategoryService(_unitOfWork);
            FinancialGoalsService = new FinancialGoalsService(_unitOfWork);
            NoteService = new NoteService(_unitOfWork);
            TransactionNoteService = new TransactionNoteService(_unitOfWork);
            TransactionService = new TransactionService(_unitOfWork);
            AccountUserService = new AccountUserService(_unitOfWork);
            RoleService = new RoleService(_unitOfWork);
            AccountUserRoleService = new AccountUserRoleService(_unitOfWork);

        }
    }

}
