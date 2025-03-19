using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.Models;
using PersonalFinance.Repository.UnifOfWorkRepository;
using PersonalFinance.Service.UnitOfWorkService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceWeb.Controllers.TransactionNoteController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionNoteController(IUnitOfWorkService unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService = unitOfWork;
        // GET: api/<TransactionNoteController>
        [HttpGet("all")]
        public async Task<List<TransactionNotes>> Get()
        {
            return await _unitOfWorkService.TransactionNoteService.GetAll();
        }

        // GET api/<TransactionNoteController>/5
        [HttpGet("{id}")]
        public async Task<TransactionNotes> Get(int Id)
        {
            return await _unitOfWorkService.TransactionNoteService.Get(u=>u.Id == Id);
        }

        // POST api/<TransactionNoteController>
        [HttpPost]
        public async Task<TransactionNotes> Post(TransactionNotes transactionNotes)
        {
            return await _unitOfWorkService.TransactionNoteService.Add(transactionNotes);

        }

        // PUT api/<TransactionNoteController>/5
        [HttpPut("{id}")]
        public async Task<TransactionNotes> Put(int Id, TransactionNotes transactionNotes)
        {
            return await _unitOfWorkService.TransactionNoteService.Update(Id,transactionNotes);

        }

        // DELETE api/<TransactionNoteController>/5
        [HttpDelete("{id}")]
        public async Task<TransactionNotes> Delete(int Id)
        {
            return await _unitOfWorkService.TransactionNoteService.Delete(u=>u.Id == Id);

        }

        // DELETE api/<TransactionNoteController>/byTransactionId/5
        [HttpDelete("byTransactionId/{id}")]
        public async Task<TransactionNotes> DeleteByTransactionId(int Id)
        {
            return await _unitOfWorkService.TransactionNoteService.Delete(u => u.TransactionId == Id);

        }
    }
}
