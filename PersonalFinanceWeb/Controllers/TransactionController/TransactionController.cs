using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using PersonalFinance.Domain.Models;
using PersonalFinance.Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceWeb.Controllers.TransactionController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController(ITransactionService _service) : ControllerBase
    {
        private readonly ITransactionService service = _service;

        // GET: api/<TransactionController>
        [HttpGet("all")]
        public async Task<List<Transaction>> GetAll()
        {
            return await service.GetAll();
        }

        // GET api/<TransactionController>/5
        [HttpGet("{id}")]
        public async Task<Transaction> Get(int id)
        {
            //var t = await _unitOfWorkService.TransactionService.Get(u => u.Id == id);
            //_ = t.TransactionNoteList;
            return await service.Get(u => u.Id == id);

            //return await _unitOfWorkService.TransactionService.GetTransaction(id);
        }

        // POST api/<TransactionController>
        [HttpPost]
        public async Task<Transaction> Post(Transaction transaction)
        {
            return await service.Add(transaction);

        }

        // PUT api/<TransactionController>/5
        [HttpPut("{id}")]
        public async Task<Transaction> Put(int Id, Transaction transaction)
        {
            return await service.Update(Id,transaction);

        }

        // DELETE api/<TransactionController>/5
        [HttpDelete("{id}")]
        public async Task<Transaction> Delete(int Id)
        {
            return await service.Delete(u=>u.Id == Id);

        }
    }
}
