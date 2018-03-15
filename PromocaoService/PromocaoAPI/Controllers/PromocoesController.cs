using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PromocaoAPI.Models;
using PromocaoAPI.Models.Repositories;
using System.Threading;

namespace PromocaoAPI.Controllers
{
    [Route("[controller]")]
    public class PromocoesController : Controller
    {
        private readonly IUnitOfWork _uow;
        public PromocoesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Promocao>> Get()
        {
            return await _uow.PromocaoRepository.FindAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Promocao> Get(int id)
        {
            return await _uow.PromocaoRepository.Get(id);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]Promocao value)
        {
            await _uow.PromocaoRepository.Save(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Promocao value)
        {
            value.Id = id;
            await _uow.PromocaoRepository.Update(value);            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _uow.PromocaoRepository.Delete(id);
            }
            catch(ArgumentException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
