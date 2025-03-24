using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.Models;
using PersonalFinance.Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceWeb.Controllers.TransactionNoteController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionNoteController(ITransactionNoteService _service) : ControllerBase
    {
        private readonly ITransactionNoteService service = _service;
        // GET: api/<TransactionNoteController>
        [HttpGet("all")]
        public async Task<List<TransactionNotes>> Get()
        {
            return await service.GetAll();
        }

        // GET api/<TransactionNoteController>/5
        [HttpGet("{id}")]
        public async Task<TransactionNotes> Get(int Id)
        {
            return await service.Get(u=>u.Id == Id);
        }

        // POST api/<TransactionNoteController>
        [HttpPost]
        public async Task<TransactionNotes> Post(TransactionNotes transactionNotes)
        {
            return await service.Add(transactionNotes);

        }

        // PUT api/<TransactionNoteController>/5
        [HttpPut("{id}")]
        public async Task<TransactionNotes> Put(int Id, TransactionNotes transactionNotes)
        {
            return await service.Update(Id,transactionNotes);

        }

        // DELETE api/<TransactionNoteController>/5
        [HttpDelete("{id}")]
        public async Task<TransactionNotes> Delete(int Id)
        {
            return await service.Delete(u=>u.Id == Id);

        }

        // DELETE api/<TransactionNoteController>/byTransactionId/5
        [HttpDelete("byTransactionId/{id}")]
        public async Task<TransactionNotes> DeleteByTransactionId(int Id)
        {
            return await service.Delete(u => u.TransactionId == Id);

        }
    }
}
