using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.Models;
using PersonalFinance.Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceWeb.Controllers.BudgetController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController(IBudgetService service) : ControllerBase
    {

        private readonly IBudgetService _service = service;

        // GET: api/<BudgetController>/all
        [HttpGet("all")]
        public Task<List<Budget>> GetAll()
        {
            return null;
        }

        // GET api/<BudgetController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BudgetController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<BudgetController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<BudgetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
