using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.Models;
using PersonalFinance.Service.UnitOfWorkService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceWeb.Controllers.NoteController
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController(IUnitOfWorkService unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService = unitOfWork;
        // GET: api/<NoteController>
        [HttpGet("all")]
        public async Task<List<Note>> GetAll()
        {
            return await _unitOfWorkService.NoteService.GetAll();
        }

        // GET api/<NoteController>/5
        [HttpGet("{id}")]
        public async Task<Note> Get(int Id)
        {
            return await _unitOfWorkService.NoteService.Get(u=>u.Id == Id);
        }

        // POST api/<NoteController>
        [HttpPost]
        public async Task<Note> Post(Note note)
        {
            return await _unitOfWorkService.NoteService.Add(note);

        }

        // PUT api/<NoteController>/5
        [HttpPut("{id}")]
        public async Task<Note> Put(int Id, Note note)
        {
            return await _unitOfWorkService.NoteService.Update(Id,note);

        }

        // DELETE api/<NoteController>/5
        [HttpDelete("{id}")]
        public async Task<Note> Delete(int Id)
        {
            return await _unitOfWorkService.NoteService.Delete(u=>u.Id == Id);

        }
    }
}
