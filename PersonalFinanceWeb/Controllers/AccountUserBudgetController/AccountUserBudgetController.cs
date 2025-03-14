using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.Models;
using PersonalFinance.Service.UnitOfWorkService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceWeb.Controllers.AccountUserBudgetController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountUserBudgetController(IUnitOfWorkService unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService = unitOfWork;


        // GET: api/<AccountUserBudgetController>/all
        [HttpGet("all")]
        public async Task<List<AccountUserBudget>> GetAll()
        {
            return await _unitOfWorkService.AccountUserBudgetService.GetAll();
        }

        // GET api/<AccountUserBudgetController>/5
        [HttpGet("{id:int}")]
        public async Task<AccountUserBudget> Get(int Id)
        {
            return await _unitOfWorkService.AccountUserBudgetService.Get(u=>u.Id == Id);

        }

        // POST api/<AccountUserBudgetController>
        [HttpPost]
        public async Task<AccountUserBudget> Post(AccountUserBudget accountUserBudget)
        {
            return await _unitOfWorkService.AccountUserBudgetService.Add(accountUserBudget);

        }

        // PUT api/<AccountUserBudgetController>/5
        [HttpPut("{id}")]
        public async Task<AccountUserBudget> Put(int Id, AccountUserBudget accountUserBudget)
        {
            return await _unitOfWorkService.AccountUserBudgetService.Update(Id,accountUserBudget);

        }

        // DELETE api/<AccountUserBudgetController>/5
        [HttpDelete("{id}")]
        public async Task<AccountUserBudget> Delete(int Id)
        {
            return await _unitOfWorkService.AccountUserBudgetService.Delete(u=>u.Id == Id);

        }
    }
}
