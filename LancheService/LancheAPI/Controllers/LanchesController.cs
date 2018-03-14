using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LancheAPI.Models;

namespace LancheAPI.Controllers
{
    [Route("[controller]")]
    public class LanchesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Lanche> Get()
        {
            return new Lanche[] { 
                new Lanche {
                    Nome = "X-Bacon",
                    Ingredientes = new List<Ingrediente>{
                        new Ingrediente{
                            Nome = "Bacon",
                            Valor = 2m
                        },
                        new Ingrediente{
                            Nome = "Hambúrger de carne",
                            Valor = 3m
                        },
                        new Ingrediente{
                            Nome = "Queijo",
                            Valor = 1.5m
                        }
                    }
                }    
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
