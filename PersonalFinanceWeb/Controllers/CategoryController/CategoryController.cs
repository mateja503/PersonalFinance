using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.Models;
using PersonalFinance.Service.UnitOfWorkService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceWeb.Controllers.CategoryController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(IUnitOfWorkService unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService = unitOfWork; 

        // GET: api/<CategoryController>/all
        [HttpGet("all")]
        public async Task<List<Category>> GetAll()
        {
            return await _unitOfWorkService.CategoryService.GetAll();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<Category> Get(int Id)
        {
            return await _unitOfWorkService.CategoryService.Get(u=>u.Id == Id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<Category> Post(Category category)
        {
            return await _unitOfWorkService.CategoryService.Add(category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<Category> Put(int Id, Category category)
        {
            return await _unitOfWorkService.CategoryService.Update(Id,category);

        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<Category> Delete(int Id)
        {
            return await _unitOfWorkService.CategoryService.Delete(u=>u.Id == Id);
        }
    }
}
