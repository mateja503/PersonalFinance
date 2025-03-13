using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using PersonalFinance.Domain.Models;
using PersonalFinance.Service.UnitOfWorkService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceWeb.Controllers.TransactionController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController(IUnitOfWorkService unitOfWorkService) : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService = unitOfWorkService;

        // GET: api/<TransactionController>
        [HttpGet("all")]
        public async Task<List<Transaction>> GetAll()
        {
            return await _unitOfWorkService.TransactionService.GetAll();
        }

        // GET api/<TransactionController>/5
        [HttpGet("{id}")]
        public async Task<Transaction> Get(int id)
        {
            return await _unitOfWorkService.TransactionService.Get(u=> u.Id == id);
        }

        // POST api/<TransactionController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<TransactionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<TransactionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
