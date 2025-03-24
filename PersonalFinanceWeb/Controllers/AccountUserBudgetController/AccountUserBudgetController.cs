using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.Models;
using PersonalFinance.Repository.Interface;
using PersonalFinance.Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceWeb.Controllers.AccountUserBudgetController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountUserBudgetController(IAccountUserBudgetService _service) : ControllerBase
    {
        private readonly IAccountUserBudgetService service = _service;


        // GET: api/<AccountUserBudgetController>/all
        [HttpGet("all")]
        public async Task<List<AccountUserBudget>> GetAll()
        {
            return await service.GetAll();
        }

        // GET api/<AccountUserBudgetController>/5
        [HttpGet("{id:int}")]
        public async Task<AccountUserBudget> Get(int Id)
        {
            return await service.Get(u=>u.Id == Id);

        }

        // POST api/<AccountUserBudgetController>
        [HttpPost]
        public async Task<AccountUserBudget> Post(AccountUserBudget accountUserBudget)
        {
            return await service.Add(accountUserBudget);

        }

        // PUT api/<AccountUserBudgetController>/5
        [HttpPut("{id}")]
        public async Task<AccountUserBudget> Put(int Id, AccountUserBudget accountUserBudget)
        {
            return await service.Update(Id,accountUserBudget);

        }

        // DELETE api/<AccountUserBudgetController>/5
        [HttpDelete("{id}")]
        public async Task<AccountUserBudget> Delete(int Id)
        {
            return await service.Delete(u=>u.Id == Id);

        }
    }
}
