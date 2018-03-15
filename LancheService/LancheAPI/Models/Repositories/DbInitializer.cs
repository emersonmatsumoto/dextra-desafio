using System.Linq;
using System.Collections.Generic;

namespace LancheAPI.Models.Repositories
{
    public static class DbInitializer
    {

        public static void Initialize(GenericDbContext context)
        {

            context.Database.EnsureCreated();

            var ingredienteEntity = context.Set<Ingrediente>();

            if (ingredienteEntity.Any())
            {
                return;
            }

            var alface = new Ingrediente
            {
                Nome = "Alface",
                Valor = 0.40m
            };
            var bacon = new Ingrediente
            {
                Nome = "Bacon",
                Valor = 2m
            };
            var hamburger = new Ingrediente
            {
                Nome = "Hambúrger de carne",
                Valor = 3m
            };
            var ovo = new Ingrediente
            {
                Nome = "Ovo",
                Valor = 0.80m
            };
            var queijo = new Ingrediente
            {
                Nome = "Queijo",
                Valor = 1.50m
            };

            var ingredientes = new Ingrediente[] { alface, bacon, hamburger, ovo, queijo };

            foreach (var i in ingredientes)
            {
                ingredienteEntity.Add(i);
            }
            context.SaveChanges();


            var lancheEntity = context.Set<Lanche>();

            var xBacon = new Lanche { Nome = "X-Bacon" };
            xBacon.LancheIngrediente = new List<LancheIngrediente> 
            {
                new LancheIngrediente {Lanche = xBacon, Ingrediente = bacon},
                new LancheIngrediente {Lanche = xBacon, Ingrediente = hamburger},
                new LancheIngrediente {Lanche = xBacon, Ingrediente = queijo},
            };

            var xBurger = new Lanche { Nome = "X-Burger" };
            xBurger.LancheIngrediente = new List<LancheIngrediente> 
            {
                new LancheIngrediente {Lanche = xBurger, Ingrediente = hamburger},
                new LancheIngrediente {Lanche = xBurger, Ingrediente = queijo},
            };

            var xEgg = new Lanche { Nome = "X-Egg" };
            xEgg.LancheIngrediente = new List<LancheIngrediente> 
            {
                new LancheIngrediente {Lanche = xEgg, Ingrediente = ovo},
                new LancheIngrediente {Lanche = xEgg, Ingrediente = hamburger},
                new LancheIngrediente {Lanche = xEgg, Ingrediente = queijo},
            };

            var xEggBacon = new Lanche { Nome = "X-Egg Bacon" };
            xEggBacon.LancheIngrediente = new List<LancheIngrediente> 
            {
                new LancheIngrediente {Lanche = xEggBacon, Ingrediente = ovo},
                new LancheIngrediente {Lanche = xEggBacon, Ingrediente = bacon},
                new LancheIngrediente {Lanche = xEggBacon, Ingrediente = hamburger},
                new LancheIngrediente {Lanche = xEggBacon, Ingrediente = queijo},
            };


            var lanches = new Lanche[] {xBacon, xBurger, xEgg, xEggBacon};
            foreach (var l in lanches)
            {
                lancheEntity.Add(l);
            }
            context.SaveChanges();
        }
    }
}