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
        public async Task<Transaction> Post(Transaction transaction)
        {
            return await _unitOfWorkService.TransactionService.Add(transaction);

        }

        // PUT api/<TransactionController>/5
        [HttpPut("{id}")]
        public async Task<Transaction> Put(int Id, Transaction transaction)
        {
            return await _unitOfWorkService.TransactionService.Update(Id,transaction);

        }

        // DELETE api/<TransactionController>/5
        [HttpDelete("{id}")]
        public async Task<Transaction> Delete(int Id)
        {
            return await _unitOfWorkService.TransactionService.Delete(u=>u.Id == Id);

        }
    }
}
