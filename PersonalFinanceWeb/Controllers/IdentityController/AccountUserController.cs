using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.Identity;
using PersonalFinance.Service.UnitOfWorkService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceWeb.Controllers.IdentityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountUserController(IUnitOfWorkService unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService = unitOfWork;
        // GET: api/<AccountUserController>
        [HttpGet("all")]
        public async Task<List<AccountUser>> Get()
        {
            return await _unitOfWorkService.AccountUserService.GetAll();
        }

        // GET api/<AccountUserController>/5
        [HttpGet("{id}")]
        public async Task<AccountUser> Get(int Id)
        {
            return await _unitOfWorkService.AccountUserService.Get(u=> u.Id == Id);

        }

        // POST api/<AccountUserController>
        [HttpPost]
        public async Task<AccountUser> Post(AccountUser accountUser)
        {
            return await _unitOfWorkService.AccountUserService.Add(accountUser);

        }

        // PUT api/<AccountUserController>/5
        [HttpPut("{id}")]
        public async Task<AccountUser> Put(int Id, AccountUser accountUser)
        {
            return await _unitOfWorkService.AccountUserService.Update(Id,accountUser);

        }

        // DELETE api/<AccountUserController>/5
        [HttpDelete("{id}")]
        public async Task<AccountUser> Delete(int Id)
        {
            return await _unitOfWorkService.AccountUserService.Delete(u=>u.Id == Id);

        }
    }
}
