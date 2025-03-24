using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.Models;
using PersonalFinance.Service.General;
using PersonalFinance.Service.Interface;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceWeb.Controllers.BudgetController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController(IBudgetService _service) : ControllerBase
    {

        private readonly IBudgetService service = _service;

        // GET: api/<BudgetController>
        [HttpGet("all")]
        public async Task<List<Budget>> GetAll()
        {
            return await service.GetAll(); 
        }

        // GET api/<BudgetController>/5
        [HttpGet("{id}")]
        public async Task<Budget> Get(int id)
        {
          
            return await service.Get(u => u.Id == id);
        }

        // POST api/<BudgetController>
        [HttpPost]
        public async Task<Budget> Post(Budget budget)
        {
            return await service.Add(budget);
        }

        // PUT api/<BudgetController>/5
        [HttpPut("{id}")]
        public async Task<Budget> Put(int id,Budget budget)
        {
            return await service.Update(id, budget);

        }

        // DELETE api/<BudgetController>/5
        [HttpDelete("{id}")]
        public async Task<Budget> Delete(int Id)
        {
            return await service.Delete(u=>u.Id == Id);
        }
    }
}
