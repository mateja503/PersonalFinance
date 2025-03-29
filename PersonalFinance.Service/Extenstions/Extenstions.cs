using Microsoft.Extensions.DependencyInjection;
using PersonalFinance.Domain.Identity;
using PersonalFinance.Service.IdentityService;
using PersonalFinance.Service.Implementation;
using PersonalFinance.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.Extenstions
{
    public static class Extenstions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services ) 
        {
            services.AddTransient<IAccountUserBudgetService, AccountUserBudgetService>();
            services.AddTransient<IAccountUserFinancialGoalsService, AccountUserFinancialGoalsService>();
            services.AddTransient<IAccountUserRoleService, AccountUserRoleService>();
            services.AddTransient<IAccountUserService, AccountUserService>();
            services.AddTransient<IBudgetService, BudgetService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IFinancialGoalsService, FinancialGoalsService>();
            services.AddTransient<INoteService, NoteService>();
            services.AddTransient<ITransactionNoteService, TransactionNoteService>();
            services.AddTransient<ITransactionService, TransactionService>();
            return services;
        }
    }
}
