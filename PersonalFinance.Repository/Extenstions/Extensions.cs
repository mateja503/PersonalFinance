using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinance.Repository.Configuration;
using PersonalFinance.Repository.Data;
using PersonalFinance.Repository.Implementation;
using PersonalFinance.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Repository.Extenstions
{
    public static class Extensions
    {
        public static IServiceCollection RegisterApplicationDbContext(
            this IServiceCollection services, 
            IConfiguration configuration) 
        {

            services.AddDbContext<ApplicationDbContext>(d => 
            {
                d.UseLazyLoadingProxies();
                d.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            });

            return services;
        }

        public static IServiceCollection RegisterRepository(
            this IServiceCollection services) 
        {
            services.AddTransient<IAccountUserBudgetRepository,AccountUserBudgetRepository>();
            services.AddTransient<IAccountUserFinancialGoalsRepository, AccountUserFinancialGoalsRepository>();
            services.AddTransient<IAccountUserRepository, AccountUserRepository>();
            services.AddTransient<IAccountUserRoleRepository, AccountUserRoleRepository>();
            services.AddTransient<IBudgetRepository, BudgetRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IFinancialGoalsRepository, FinancialGoalsRepository>();
            services.AddTransient<INoteRepository, NoteRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ITransactionNotesRepository, TransactionNotesRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            return services;
        }
    }
}
