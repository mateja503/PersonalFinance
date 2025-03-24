using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.Models;
using PersonalFinance.Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceWeb.Controllers.CategoryController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService _service) : ControllerBase
    {
        private readonly ICategoryService service =  _service; 

        // GET: api/<CategoryController>/all
        [HttpGet("all")]
        public async Task<List<Category>> GetAll()
        {
            return await service.GetAll();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<Category> Get(int Id)
        {
            return await service.Get(u=>u.Id == Id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<Category> Post(Category category)
        {
            return await service.Add(category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<Category> Put(int Id, Category category)
        {
            return await service.Update(Id,category);

        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<Category> Delete(int Id)
        {
            return await service.Delete(u=>u.Id == Id);
        }
    }
}
