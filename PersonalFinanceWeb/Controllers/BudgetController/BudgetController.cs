using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.Models;
using PersonalFinance.Service.General;
using PersonalFinance.Service.Interface;
using PersonalFinance.Service.UnitOfWorkService;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceWeb.Controllers.BudgetController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController(IUnitOfWorkService unitOfWork): ControllerBase
    {

        private readonly IUnitOfWorkService _unitOfWorkService = unitOfWork;

        // GET: api/<BudgetController>
        [HttpGet("all")]
        public async Task<List<Budget>> GetAll()
        {
            return await _unitOfWorkService.BudgetService.GetAll(); 
        }

        // GET api/<BudgetController>/5
        [HttpGet("{id}")]
        public async Task<Budget> Get(int id)
        {
          
            return await _unitOfWorkService.BudgetService.Get(u => u.Id == id);
        }

        // POST api/<BudgetController>
        [HttpPost]
        public async Task<Budget> Post(Budget budget)
        {
            return await _unitOfWorkService.BudgetService.Add(budget);
        }

        // PUT api/<BudgetController>/5
        [HttpPut("{id}")]
        public async Task<Budget> Put(int id,Budget budget)
        {
            return await _unitOfWorkService.BudgetService.Update(id, budget);

        }

        // DELETE api/<BudgetController>/5
        [HttpDelete("{id}")]
        public async Task<Budget> Delete(int Id)
        {
            return await _unitOfWorkService.BudgetService.Delete(u=>u.Id == Id);
        }
    }
}
