using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceWeb.Controllers.AccountUserFinancialGoalsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountUserFinancialGoalsController : ControllerBase
    {
        // GET: api/<AccountUserFinancialGoalsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountUserFinancialGoalsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountUserFinancialGoalsController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<AccountUserFinancialGoalsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<AccountUserFinancialGoalsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
