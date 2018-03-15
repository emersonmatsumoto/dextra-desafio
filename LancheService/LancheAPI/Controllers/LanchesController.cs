using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LancheAPI.Models;
using LancheAPI.Models.Repositories;

namespace LancheAPI.Controllers
{
    [Route("[controller]")]
    public class LanchesController : Controller
    {
        // GET api/values
        private readonly IUnitOfWork _uow;

        public LanchesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<IEnumerable<Lanche>> Get()
        {
            var lanches = await _uow.LancheRepository.FindAll();
            return lanches;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Lanche> Get(int id)
        {
            return await _uow.LancheRepository.Get(id);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]Lanche value)
        {
            await _uow.LancheRepository.Save(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Lanche value)
        {
            value.Id = id;
            await _uow.LancheRepository.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _uow.LancheRepository.Delete(id);
            }
            catch(ArgumentException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
