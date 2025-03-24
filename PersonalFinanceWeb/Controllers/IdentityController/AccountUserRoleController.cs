using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.Identity;
using PersonalFinance.Service.IdentityService.RoleService;
using PersonalFinance.Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceWeb.Controllers.IdentityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountUserRoleController(IAccountUserRoleService _service) : ControllerBase
    {
        private readonly IAccountUserRoleService service = _service;
        // GET: api/<AccountUserRoleController>
        [HttpGet("all")]
        public async Task<List<AccountUserRole>> GetAll()
        {
            return await service.GetAll();
        }

        // GET api/<AccountUserRoleController>/5
        [HttpGet("{id}")]
        public async Task<AccountUserRole> Get(int Id)
        {
            return await service.Get(u=>u.Id == Id);
        }

        // POST api/<AccountUserRoleController>
        [HttpPost]
        public async Task<AccountUserRole> Post(AccountUserRole accountUserRole)
        {
            return await service.Add(accountUserRole);

        }

        // PUT api/<AccountUserRoleController>/5
        [HttpPut("{id}")]
        public async Task<AccountUserRole> Put(int Id, AccountUserRole accountUserRole)
        {
            return await service.Update(Id,accountUserRole);

        }

        // DELETE api/<AccountUserRoleController>/5
        [HttpDelete("{id}")]
        public async Task<AccountUserRole> Delete(int Id)
        {
            return await service.Delete(u=>u.Id == Id);

        }
    }
}
