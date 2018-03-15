using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LancheAPI.Models.Repositories
{
    public class LancheRepository : GenericRepository<Lanche>
    {
        public LancheRepository(DbContext dbContext) : base(dbContext)
        {            
        }

        public async Task<IEnumerable<Lanche>> FindAll()
        {
            return await _dbContext.Set<Lanche>()
                .GroupJoin(_dbContext.Set<LancheIngrediente>(), o => o.Id, i => i.LancheId, (o, i) => new {lanche = o, ingredientes = i})
                .Select(s => 
                    new Lanche 
                    {
                        Id = s.lanche.Id,
                        Nome = s.lanche.Nome,
                        Ingredientes = s.ingredientes.Select(m => m.Ingrediente).ToList()
                    })
                .ToListAsync();
        }

        public async Task<Lanche> Get(int id)
        {
            return await _dbContext.Set<Lanche>()
                .Where(w => w.Id == id)
                .GroupJoin(_dbContext.Set<LancheIngrediente>(), o => o.Id, i => i.LancheId, (o, i) => new {lanche = o, ingredientes = i})
                .Select(s => 
                    new Lanche 
                    {
                        Id = s.lanche.Id,
                        Nome = s.lanche.Nome,
                        Ingredientes = s.ingredientes.Select(m => m.Ingrediente).ToList()
                    })
                .FirstOrDefaultAsync();
        }

    }
}