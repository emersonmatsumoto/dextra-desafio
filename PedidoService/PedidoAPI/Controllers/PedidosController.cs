using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using PedidoAPI.Models;
using PedidoAPI.Models.Repositories;

namespace PedidoAPI.Controllers
{
    [Route("[controller]")]
    public class PedidosController : Controller
    {
        private readonly IUnitOfWork _uow;

        public PedidosController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Pedido>> Get()
        {            
            return await _uow.PedidoRepository.FindAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Pedido> Get(int id)
        {
            return await _uow.PedidoRepository.Get(id);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]Pedido value)
        {
            await _uow.PedidoRepository.Save(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Pedido value)
        {
            value.Id = id;
            await _uow.PedidoRepository.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             try
            {
                await _uow.PedidoRepository.Delete(id);
            }
            catch(ArgumentException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
