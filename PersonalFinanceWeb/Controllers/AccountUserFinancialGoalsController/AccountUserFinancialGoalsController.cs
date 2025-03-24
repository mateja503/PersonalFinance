using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using PersonalFinance.Domain.Models;
using PersonalFinance.Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceWeb.Controllers.AccountUserFinancialGoalsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountUserFinancialGoalsController(IAccountUserFinancialGoalsService _service) : ControllerBase
    {
        private readonly IAccountUserFinancialGoalsService service = _service;
        // GET: api/<AccountUserFinancialGoalsController>
        [HttpGet("all")]
        public async Task<List<AccountUserFinancialGoals>> Get()
        {
            return await service.GetAll();
        }

        // GET api/<AccountUserFinancialGoalsController>/5
        [HttpGet("{id}")]
        public async Task<AccountUserFinancialGoals> Get(int Id)
        {
            return await service.Get(u=>u.Id == Id);

        }

        // POST api/<AccountUserFinancialGoalsController>
        [HttpPost]
        public async Task<AccountUserFinancialGoals> Post(AccountUserFinancialGoals accountUserFinancialGoals)
        {
            return await service.Add(accountUserFinancialGoals);

        }

        // PUT api/<AccountUserFinancialGoalsController>/5
        [HttpPut("{id}")]
        public async Task<AccountUserFinancialGoals> Put(int Id, AccountUserFinancialGoals accountUserFinancialGoals)
        {
            return await service.Update(Id,accountUserFinancialGoals);

        }

        // DELETE api/<AccountUserFinancialGoalsController>/5
        [HttpDelete("{id}")]
        public async Task<AccountUserFinancialGoals> Delete(int Id)
        {
            return await service.Delete(u=>u.Id == Id);

        }
    }
}
