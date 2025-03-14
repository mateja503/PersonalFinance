using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.Identity;
using PersonalFinance.Service.UnitOfWorkService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceWeb.Controllers.IdentityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountUserRoleController(IUnitOfWorkService unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService = unitOfWork;
        // GET: api/<AccountUserRoleController>
        [HttpGet("all")]
        public async Task<List<AccountUserRole>> GetAll()
        {
            return await _unitOfWorkService.AccountUserRoleService.GetAll();
        }

        // GET api/<AccountUserRoleController>/5
        [HttpGet("{id}")]
        public async Task<AccountUserRole> Get(int Id)
        {
            return await _unitOfWorkService.AccountUserRoleService.Get(u=>u.Id == Id);
        }

        // POST api/<AccountUserRoleController>
        [HttpPost]
        public async Task<AccountUserRole> Post(AccountUserRole accountUserRole)
        {
            return await _unitOfWorkService.AccountUserRoleService.Add(accountUserRole);

        }

        // PUT api/<AccountUserRoleController>/5
        [HttpPut("{id}")]
        public async Task<AccountUserRole> Put(int Id, AccountUserRole accountUserRole)
        {
            return await _unitOfWorkService.AccountUserRoleService.Update(Id,accountUserRole);

        }

        // DELETE api/<AccountUserRoleController>/5
        [HttpDelete("{id}")]
        public async Task<AccountUserRole> Delete(int Id)
        {
            return await _unitOfWorkService.AccountUserRoleService.Delete(u=>u.Id == Id);

        }
    }
}
