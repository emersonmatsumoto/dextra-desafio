using System.Linq;
using System.Collections.Generic;

namespace PromocaoAPI.Models.Repositories
{
    public static class DbInitializer
    {

        public static void Initialize(GenericDbContext context)
        {

            context.Database.EnsureCreated();

            var promocaoEntity = context.Set<Promocao>();

            if (promocaoEntity.Any())
            {
                return;
            }

            var light = new Promocao
            {
                Nome = "Light",
                Lanches = new List<Lanche> 
                {
                    new Lanche
                    {
                        Nome = "X-Egg"
                    }
                }
            };
            var carne = new Promocao
            {
                Nome = "Muita carne",
                Lanches = new List<Lanche> 
                {
                    new Lanche
                    {
                        Nome = "X-Burguer"
                    }
                }
            };
            var queijo = new Promocao
            {
                Nome = "Muito queijo",
                Lanches = new List<Lanche> 
                {
                    new Lanche
                    {
                        Nome = "X-Bacon"
                    },
                    new Lanche
                    {
                        Nome = "X-Egg Bacon"
                    }
                }
            };

            var promocoes = new Promocao[] { light, queijo, carne };

            foreach (var p in promocoes)
            {
                promocaoEntity.Add(p);
            }
            context.SaveChanges();
        }
    }
}