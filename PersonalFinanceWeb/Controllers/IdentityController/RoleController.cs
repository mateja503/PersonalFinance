using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.Identity.RoleManager;
using PersonalFinance.Service.IdentityService.RoleService;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceWeb.Controllers.IdentityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController(IRoleService _service) : ControllerBase
    {
        private readonly IRoleService service = _service;
        // GET: api/<RoleController>
        [HttpGet("all")]
        public async Task<List<Role>> Get()
        {
            return await service.GetAll();
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<Role> Get(int Id)
        {
            return await service.Get(u=>u.Id == Id);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<Role> Post(Role role)
        {
            return await service.Add(role);

        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task<Role> Put(int Id, Role role)
        {
            return await service.Update(Id,role);

        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task<Role> Delete(int Id)
        {
            return await service.Delete(u=>u.Id == Id);

        }
    }
}
