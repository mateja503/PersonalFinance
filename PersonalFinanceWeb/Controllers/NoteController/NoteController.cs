using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.Models;
using PersonalFinance.Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceWeb.Controllers.NoteController
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController(INoteService _service) : ControllerBase
    {
        private readonly INoteService service = _service;
        // GET: api/<NoteController>
        [HttpGet("all")]
        public async Task<List<Note>> GetAll()
        {
            return await service.GetAll();
        }

        // GET api/<NoteController>/5
        [HttpGet("{id}")]
        public async Task<Note> Get(int Id)
        {
            return await service.Get(u=>u.Id == Id);
        }

        // POST api/<NoteController>
        [HttpPost]
        public async Task<Note> Post(Note note)
        {
            return await service.Add(note);

        }

        // PUT api/<NoteController>/5
        [HttpPut("{id}")]
        public async Task<Note> Put(int Id, Note note)
        {
            return await service.Update(Id,note);

        }

        // DELETE api/<NoteController>/5
        [HttpDelete("{id}")]
        public async Task<Note> Delete(int Id)
        {
            return await service.Delete(u=>u.Id == Id);

        }
    }
}
