using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinance.Domain.Identity;
using PersonalFinance.Domain.Identity.RoleManager;
using PersonalFinance.Domain.Identity.RoleManager.Enumiration;
using PersonalFinance.Domain.UserRegistryModel;
using PersonalFinance.Repository.Data;
using PersonalFinance.Repository.General;
using PersonalFinance.Repository.Implementation;
using PersonalFinance.Repository.Interface;
using PersonalFinance.Service.General;
using PersonalFinance.Service.IdentityService.IdentityException;
using Shared.Configuration.Setup.Security;
using System.Reflection.Metadata.Ecma335;

namespace PersonalFinance.Service.IdentityService
{
    public class AccountUserService : GeneralService<AccountUser,IAccountUserRepository>, IAccountUserService
    {
        private readonly IAccountUserRepository _repositoryUser;
        private readonly IRoleRepository _repositoryRole;
        private readonly IAccountUserRoleRepository _repositoryAccountUserRole;
        
        private readonly JWTProvider? _provider;

       

        public AccountUserService(IAccountUserRepository repository,ApplicationDbContext db,JWTProvider provider) : base(repository)
        {
            _repositoryUser = new AccountUserRepository(db);
            _repositoryRole = new RoleRepository(db);
            _repositoryAccountUserRole = new AccountUserRoleRepository(db);
            _provider = provider;
        }

        public async Task<AccountUser> Login(AccountUserLoginModel model)
        {
            string? username = model.username;
            string? password = model.password;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new FormNotCompletelyEnteredException();
            }

            var user = await _repositoryUser.Get(u => u.UserAuthentication.au_username == username);

            if (user == null) 
            {
                throw new LogInFailedException();
            }

            bool flag = user.UserAuthentication.au_password == password;

            if (!flag) 
            {
                throw new LogInFailedException();

            }
            user.UserAuthentication.Token = _provider.GenerateJWT(user);
            await ((AccountUserRepository)_repositoryUser).Update(user);
            
            //_repositoryUser.Detach();
            return user;

        }

        public async Task<AccountUser> Register(AccoutUserRegistryModel model)
        {
            string? username = model.username;
            string? email = model.email;
            string? password = model.password;
            string? name = model.name;
            string? surname = model.surname;
            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname)) 
            {
                throw new FormNotCompletelyEnteredException();
            }

            var user = await _repositoryUser.Get(u => u.email == email);

            if (user != null) 
            {
                throw new UserWithEmailExistsException(email);
            }
            var userWithSameUserName = await _repositoryUser.Get(u => u.UserAuthentication.au_username == username);
            if (userWithSameUserName != null) 
            {
                throw new UserWithUserNemeExistsException(username);
            }
            //var (passwordHash, salt) = PasswordHash.GeneratePasswordHash(request.Password);


            var obj = new AccountUser
            {
                Name = name,
                Surname = surname,
                email = email,

                UserAuthentication = new Auth
                {
                    au_username = username,
                    au_password = password,
                
                }

            };
            obj.UserAuthentication.Token = _provider.GenerateJWT(obj);
            await _repositoryUser.Add(obj);
            _ = obj.UserAuthentication;
            var userRoles = await _repositoryAccountUserRole.GetAll();
            var roleEnum = RoleEnum.User;
           
            if (userRoles.Count() == 0) 
            {
                roleEnum = RoleEnum.Admin;
            }

            var role = new Role
            {
                UserRole = roleEnum,
            };

            await _repositoryRole.Add(role);

            var r = new AccountUserRole
            {

                AccountUserId = obj.Id,
                RoleId = role.Id

            };

            await _repositoryAccountUserRole.Add(r);

            //_repositoryAccountUserRole.Detach();

            return obj;



        }

        public async Task<AccountUser> Update(int Id, AccountUser accountUser)
        {
            var obj = await _repositoryUser.Get(u => u.Id == Id);

            obj.Name = accountUser.Name;
            obj.Surname = accountUser.Surname;
            obj.email = accountUser.email;
            obj.Roles = accountUser.Roles;
            obj.AccontUserFinancialGoalList = accountUser.AccontUserFinancialGoalList;
            obj.AccountUserBudgetList = accountUser.AccountUserBudgetList;
            obj.UserAuthentication.au_username = accountUser.UserAuthentication.au_username;
            obj.UserAuthentication.au_password = accountUser.UserAuthentication.au_password;

            return await ((AccountUserRepository)_repositoryUser).Update(obj);
        }

        public async Task<AccountUser> ValidateSession(string token)
        {

            AccountUser? user = await _repositoryUser.Get(u => u.UserAuthentication.Token == token);
            if (user == null) 
            {
                throw new UnauthorizedAccessException("Invalid user ID format in token.");
            }
            //_repositoryUser.Attach();
            //_ = user.Roles;
            //_ = user.AccontUserFinancialGoalList;
            //var r = user;

            //var isProxy = user.GetType().Namespace == "System.Data.Entity.DynamicProxies";
            //Console.WriteLine($"Is proxy: {isProxy}");
            //_repositoryUser.Detach();
            return user;
        }
    }
}
