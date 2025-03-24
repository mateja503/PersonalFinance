using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using PersonalFinance.Domain.Identity;
using PersonalFinance.Domain.UserRegistryModel;
using PersonalFinance.Service.IdentityService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceWeb.Controllers.IdentityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountUserController(IAccountUserService _service) : ControllerBase
    {
        private readonly IAccountUserService service = _service;
        // GET: api/<AccountUserController>
        [HttpGet("all")]
        public async Task<List<AccountUser>> Get()
        {
            return await service.GetAll();
        }

        // GET api/<AccountUserController>/5
        [HttpGet("{id}")]
        public async Task<AccountUser> Get(int Id)
        {
            return await service.Get(u=> u.Id == Id);

        }

        [HttpGet("validate-user")]
        public async Task<AccountUser> GetCurrentUser()
        {

            return await service
                .ValidateSession(Request.Headers.Authorization.ToString().Replace("Bearer ", ""));

        }

        [HttpPost("register")]
        public async Task<AccountUser> Register(AccoutUserRegistryModel model)
        {
            return await service.Register(model);

        }


        [HttpPost("login")]
        public async Task<AccountUser> Login(AccountUserLoginModel model)
        {
            return await service.Login(model);

        }

        // PUT api/<AccountUserController>/5
        [HttpPut("{id}")]
        public async Task<AccountUser> Put(int Id, AccountUser accountUser)
        {
            return await service.Update(Id,accountUser);

        }

        // DELETE api/<AccountUserController>/5
        [HttpDelete("{id}")]
        public async Task<AccountUser> Delete(int Id)
        {
            return await service.Delete(u=>u.Id == Id);

        }
    }
}
