using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LancheAPI.Models.Repositories
{
    public class IngredienteRepository : GenericRepository<Ingrediente>
    {
        public IngredienteRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Ingrediente>> FindAll()
        {
            return await _dbContext.Set<Ingrediente>()
               .GroupJoin(_dbContext.Set<LancheIngrediente>(), o => o.Id, i => i.IngredienteId, (o, i) => new { ingrediente = o, lanches = i })
               .Select(s =>
                   new Ingrediente
                   {
                       Id = s.ingrediente.Id,
                       Nome = s.ingrediente.Nome,
                       Valor = s.ingrediente.Valor,
                       Lanches = s.lanches.Select(m => m.Lanche).ToList()
                   })
               .ToListAsync();
        }

        public async Task<Ingrediente> Get(int id)
        {
            return await _dbContext.Set<Ingrediente>()
                .Where(w => w.Id == id)
                .GroupJoin(_dbContext.Set<LancheIngrediente>(), o => o.Id, i => i.IngredienteId, (o, i) => new { ingrediente = o, lanches = i })
                .Select(s =>
                    new Ingrediente
                    {
                        Id = s.ingrediente.Id,
                        Nome = s.ingrediente.Nome,
                        Valor = s.ingrediente.Valor,
                        Lanches = s.lanches.Select(m => m.Lanche).ToList()
                    })
                .FirstOrDefaultAsync();
        }
    }
}