using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.Models;
using PersonalFinance.Service.UnitOfWorkService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceWeb.Controllers.FinancialGoalsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialGoalsController(IUnitOfWorkService unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService = unitOfWork;
        // GET: api/<FinancialGoalsController>
        [HttpGet("all")]
        public async Task<List<FinancialGoals>> GetAll()
        {
            return await _unitOfWorkService.FinancialGoalsService.GetAll();
        }

        // GET api/<FinancialGoalsController>/5
        [HttpGet("{id}")]
        public async Task<FinancialGoals> Get(int Id)
        {
            return await _unitOfWorkService.FinancialGoalsService.Get(u => u.Id == Id);
        }

        // POST api/<FinancialGoalsController>
        [HttpPost]
        public async Task<FinancialGoals> Post(FinancialGoals financialGoals)
        {
            return await _unitOfWorkService.FinancialGoalsService.Add(financialGoals);
        }

        // PUT api/<FinancialGoalsController>/5
        [HttpPut("{id}")]
        public async Task<FinancialGoals> Put(int Id, FinancialGoals financialGoals)
        {
            return await _unitOfWorkService.FinancialGoalsService.Update(Id, financialGoals);

        }

        // DELETE api/<FinancialGoalsController>/5
        [HttpDelete("{id}")]
        public async Task<FinancialGoals> Delete(int Id)
        {
            return await _unitOfWorkService.FinancialGoalsService.Delete(u=> u.Id == Id);

        }
    }
}
