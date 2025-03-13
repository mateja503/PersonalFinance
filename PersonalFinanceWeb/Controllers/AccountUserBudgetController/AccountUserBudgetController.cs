using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceWeb.Controllers.AccountUserBudgetController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountUserBudgetController : ControllerBase
    {
        // GET: api/<AccountUserBudgetController>/all
        [HttpGet("all")]
        public IEnumerable<string> GetAll()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountUserBudgetController>/5
        [HttpGet("{id:int}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountUserBudgetController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<AccountUserBudgetController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<AccountUserBudgetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
