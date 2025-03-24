using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.Models;
using PersonalFinance.Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceWeb.Controllers.FinancialGoalsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialGoalsController(IFinancialGoalsService _service) : ControllerBase
    {
        private readonly IFinancialGoalsService service = _service;
        // GET: api/<FinancialGoalsController>
        [HttpGet("all")]
        public async Task<List<FinancialGoals>> GetAll()
        {
            return await service.GetAll();
        }

        // GET api/<FinancialGoalsController>/5
        [HttpGet("{id}")]
        public async Task<FinancialGoals> Get(int Id)
        {
            return await service.Get(u => u.Id == Id);
        }

        // POST api/<FinancialGoalsController>
        [HttpPost]
        public async Task<FinancialGoals> Post(FinancialGoals financialGoals)
        {
            return await service.Add(financialGoals);
        }

        // PUT api/<FinancialGoalsController>/5
        [HttpPut("{id}")]
        public async Task<FinancialGoals> Put(int Id, FinancialGoals financialGoals)
        {
            return await service.Update(Id, financialGoals);

        }

        // DELETE api/<FinancialGoalsController>/5
        [HttpDelete("{id}")]
        public async Task<FinancialGoals> Delete(int Id)
        {
            return await service.Delete(u=> u.Id == Id);

        }
    }
}
