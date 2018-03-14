using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LancheAPI.Models;

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

            // return new Ingrediente[] { 
            //     new Ingrediente {
            //         Nome = "Alface",
            //         Valor = 0.40m
            //     },    
            //     new Ingrediente {
            //         Nome = "Bacon",
            //         Valor = 2m
            //     },
            //     new Ingrediente {
            //         Nome = "Hambúrger de carne",
            //         Valor = 3m
            //     },
            //     new Ingrediente {
            //         Nome = "Ovo",
            //         Valor = 0.80m
            //     },
            //     new Ingrediente {
            //         Nome = "Queijo",
            //         Valor = 1.50m
            //     },
            // };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]Ingrediente value)
        {
            await _uow.IngredienteRepository.Save(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
