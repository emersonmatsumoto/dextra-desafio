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
    public class IngredientesController : Controller
    {
        private readonly IUnitOfWork _uow;
        public IngredientesController (IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Ingrediente>> Get()
        {
            return await _uow.IngredienteRepository.FindAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Ingrediente> Get(int id)
        {
            return await _uow.IngredienteRepository.Get(id);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]Ingrediente value)
        {
            await _uow.IngredienteRepository.Save(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Ingrediente value)
        {
            value.Id = id;
            await _uow.IngredienteRepository.Update(value);
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
